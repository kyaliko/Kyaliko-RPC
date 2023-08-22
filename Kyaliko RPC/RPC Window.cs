using DiscordRPC;
using DiscordRPC.Message;
using DiscordRPC.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Button = DiscordRPC.Button;
using System.CodeDom;

namespace Kyaliko_RPC
{
    public partial class Form1 : Form
    {
        private static DiscordRPC.Logging.LogLevel logLevel = DiscordRPC.Logging.LogLevel.Trace;

        private static int discordPipe = -1;

        public DiscordRpcClient client;
        public bool button1enabled = false;
        public bool button2enabled = false;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Initialize_Click(object sender, EventArgs e)
        {
            inicheck();
        }

        //all weird functions

        private void inicheck()
        {
            try
            {
                if (client == null)
                {
                    ini();
                }
                else if (client.IsInitialized)
                {
                    reini();
                }
            }
            catch
            {
                MessageBox.Show("F", "Wasdasdasd");
            }
        }
        private void lblimg()
        {
            try
            {
                this.label1.Text = this.client.CurrentUser.Username;
                this.guna2CirclePictureBox1.Load(this.client.CurrentUser.GetAvatarURL(User.AvatarFormat.PNG, User.AvatarSize.x128));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "uh oh");
            }
            
        }
        public void reini()
        {
            try
            {
                client.Deinitialize();
                client = new DiscordRpcClient("0");
                client.Dispose();
                ini();
                update();
                notifyIcon3.ShowBalloonTip(1000);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
            }
        }

        private void ini()
        {
            client = new DiscordRpcClient(ID.Text);
            client.Initialize();
            Thread.Sleep(3000);
            lblimg();
            notifyIcon2.ShowBalloonTip(1000);
        }

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {
            web1.Visible = false;
            guna2ControlBox2.Visible = false;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            web1.Size = new Size(924, 394);
            web1.Visible = true;
            guna2ControlBox2.Visible = true;
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            update();
        }

        private void update()
        {
            if (client == null)
            {
                return;
            }
            else if (client.IsInitialized == true)
            {
                try
                {
                    RichPresence uwu = new RichPresence();
                    uwu.Details = Details.Text;
                    uwu.Assets = new Assets
                    {
                        LargeImageKey = this.LargeKey.Text,
                        LargeImageText = this.LargeText.Text,
                        SmallImageKey = this.SmallKey.Text,
                        SmallImageText = this.SmallText.Text,
                    };
                    uwu.State = State.Text;
                    if (guna2ToggleSwitch1.Checked)
                    {
                        uwu.Timestamps = Timestamps.Now;
                    }
                    
                    if (button1enabled == true)
                    {
                        uwu.Buttons = new Button[]
                        {
                            new DiscordRPC.Button() { Label = ButtonText1.Text, Url = ButtonLink1.Text }
                        };
                        if (button2enabled == true)
                        {
                            uwu.Buttons = new Button[]
                            {
                                new DiscordRPC.Button() { Label = ButtonText1.Text, Url = ButtonLink1.Text },
                                new DiscordRPC.Button() { Label = ButtonText2.Text, Url = ButtonLink2.Text }
                            };
                        };
                    }

                    client.SetPresence(uwu);
                    label2.Text = uwu.Details;
                    label3.Text = uwu.State;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Maybe this error message can help you: \n\n" + ex.Message, "Failed");
                    notifyIcon1.Text = "RPC Update Failed";
                    notifyIcon1.BalloonTipText = "make sure you have a URL and text in the Button TxTBoxes";
                    notifyIcon1.BalloonTipIcon = ToolTipIcon.Error;
                    notifyIcon1.ShowBalloonTip(2000);
                }
            }
        }

        private void guna2ControlBox2_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2ControlBox2_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void guna2ControlBox2_MouseUp(object sender, MouseEventArgs e)
        {
            guna2ControlBox2.BorderThickness = 0;
        }

        private void Button1Enable_Click(object sender, EventArgs e)
        {
            if(button1enabled == false)
            {
                Button1Enable.Text = "Disable Button 1";
                button1enabled = true;
                ButtonText1.Enabled = true;
                ButtonLink1.Enabled = true;
            }
            else if(button1enabled == true)
            {
                Button1Enable.Text = "Enable Button 1";
                button1enabled = false;
                ButtonText1.Enabled = false;
                ButtonLink1.Enabled = false;
            }
        }

        private void Button1Disable_Click(object sender, EventArgs e)
        {
            button1enabled = false;
            ButtonText1.Enabled = false;
            ButtonText2.Enabled = false;
        }

        private void Button2Enable_Click(object sender, EventArgs e)
        {

            if (button2enabled == false)
            {
                Button2Enable.Text = "Disable Button 2";
                button2enabled = true;
                ButtonText2.Enabled = true;
                ButtonLink2.Enabled = true;
            }
            else if (button2enabled == true)
            {
                Button2Enable.Text = "Enable Button 2";
                button2enabled = false;
                ButtonText2.Enabled = false;
                ButtonLink2.Enabled = false;
            }
        }

        private void Button2Disable_Click(object sender, EventArgs e)
        {
            button2enabled = false;
            ButtonText2.Enabled = false;
            ButtonLink2.Enabled = false;
        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
