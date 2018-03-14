using SassyMQ.Lib.RabbitMQ;
using SassyMQ.YA.Lib;
using SassyMQ.YA.Lib.RabbitMQ;
using SassyMQ.YA.Lib.RMQActors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YesAndOST.Lib.DataClasses;

namespace WindowsYesAndApp
{
    public partial class MainForm : Form
    {
        public SMQPerson PersonActor { get; }
        public Person Person { get; private set; }
        public Avatar Avatar { get; private set; }

        public MainForm()
        {
            InitializeComponent();
            this.PersonActor = new SMQPerson();
            this.PersonActor.ReplyTo += PersonActor_ReplyTo;

        }

        private void PersonActor_ReplyTo(object sender, PayloadEventArgs<YAPayload> e)
        {
            if (e.Payload.IsLexiconTerm(LexiconTermEnum.person_hello_armediator))
            {
                this.Person = e.Payload.Person;
                this.Avatar = e.Payload.Person.Avatar;
                this.Text = this.Avatar.Handle;
                this.PersonActor.PersonSeePeople(e.Payload);
            }
            else if (e.Payload.IsLexiconTerm(LexiconTermEnum.person_seepeople_armediator))
            {
                listBox1.DataSource = e.Payload.People;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
            this.PersonActor.Disconnect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var helloPayload = this.PersonActor.CreatePayload();
            helloPayload.Person = new YesAndOST.Lib.DataClasses.Person()
            {
                EmailAddress = this._emailAddressTextBox1.Text
            };

            this.PersonActor.PersonHello(helloPayload);
        }
    }
}
