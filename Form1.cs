//save in folder instead of root



//nice to have
//progress bar in background to show more progress details like spell name / count
//retry failed spells by fixing casing (proper case then lower The, Of, A, postpend _(Spell) ex:Sacrifice. tru ` instead of '
//let user choose location to which save gtp files
//save colors custom choices to file. button to set defaults.



//QA
//ench done?
//fails: Gangrenous Touch of Zum'uul



using System;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using System.Windows.Forms;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
using System.Linq;
using System.Xml;
//using System.Text;
//using System.Threading.Tasks;


/// <summary>
/// 
///#######################################################
///CREATED BY Github user: BrettsRepo
///CONVERTED from previous tool
///#######################################################
///APPLICATION: p99-gina-creator
///#######################################################
///PURPOSE: p99-gina-creator aims to make it easier for users to create files imported by 
///the GINA application for user specified p99 EverQuest spells.
///#######################################################
///CONTEXT:
///A community of EverQuest enthusiasts relive their youth on an emulated EverQuest server Project1999.
///EverQuest was created in 1999 and was one of the first multiplayer online games. World of Warcraft built
///their ecosystem on the backs of EverQuest’s proven ideas and business model. EverQuest(EQ) is 
///essentially an online Dungeons and Dragons game where you team up with friends to defeat 
///NPC enemies and advance your character. EverQuest is still operating it's game/SaaS business in 2022!
/// https://project1999.com
///EQ notifies the player of all information via a text box window(things like spell casting, resists, 
///spells landing, meleeing an enemy). The information is also saved in a log file.Text only notification 
///makes it very hard for EQ players to know when things are happening due to so much information being 
///delivered at once.The application GINA was created to help players with this difficulty.
///GINA (not part of EQ application) reads the EQ log file, parses when specific phrases are found, 
///and is triggered to give the user text information and/or timers. GINA is heavily used by the project1999 EQ community. 
/// https://eq.gimasoft.com/gina/
///However, EQ p99 has hundreds (maybe thousands?) of spells and creating the GINA triggers in the GINA application is 
///very tedious and time consuming. Thankfully, GINA does have an option to import triggers. Files imported by GINA 
///are zipped (.zip) xml files that dictate all attributes of each trigger.
///p99-gina-creator application aims to make it easy for users to create files imported by GINA for all 
///the user specified spells. For each user specified spell it obtains the p99 wiki webpage spellinformation,
///scrapes and parses the data from the page, and creates a single .gtp (GINA Trigger Package) GINA Import file.
///Users then import the triggers into their GINA application. Spells Triggers are arranged in 3 general
///categories; CASTING is spell cast timers, SELF is beneficial/detremental spells cast on your character,
///and OTHER is beneficial/detrimental spells cast on others (not your character).
///#######################################################
/// </summary>


namespace p99_gina_creator
{

    public partial class formMain : Form
    {
        public formMain()
        {
            InitializeComponent();
        }

        string colorBFHSU = "BLUE-#FF1292BE";
        string colorAJR = "TURQUOISE-#FF5EC3B7";
        string colorCDI = "RED-#FFD03E3E";
        string colorNPV = "GREEN-#FF137B0E";
        string colorGM = "GRAY-#FF696969";
        string colorE = "OLIVE-#FF75B427";
        string colorK = "YELLOW-#FFFCD84B";
        string colorL = "PURPLE-#FF833783";
        string colorO = "PEACH-#FFEF8632";
        string colorQ = "BROWN-#FF58370B";
        string colorT = "ORANGE-#FFF4A10F";

        
        
        string WikiSource;
        
        double delayTime = 0.15; 
        int characterLevel = 60; 

        StringBuilder FailureList = new StringBuilder();
        StringBuilder SuccessList = new StringBuilder();


        private void formMain_Load(object sender, EventArgs e)
        {
            //populate the level combo box with values: 1-60
            for (int i = 60; i > 0; i--)
            {
                comboBoxLevel.Items.Add(i.ToString());
            }
            comboBoxLevel.SelectedIndex = 0;

            //populate the delay combo box, 25ms increments
            for (int i = 1; i < 41; i++)
            {
                comboBoxDelay.Items.Add((i * 25).ToString());
            }
            comboBoxDelay.SelectedIndex = 5;

            //populate the colors combobox for icon colors
            for (int i = 65; i < 87; i++)
            {
                comboBoxColors.Items.Add(Convert.ToChar(i));
            }
            comboBoxColors.SelectedIndex = 0;

            Image mi = Properties.Resources.spellthemes;
            pictureBoxAllIcons.Image = mi;
            pictureBoxAllIcons.Left = 0;
            pictureBoxAllIcons.Top = 0;
            pictureBoxAllIcons.Width = Width;
            pictureBoxAllIcons.Height = Height;

            linkLabelProgressBar.Text = "";

            radioButtonUseThemeColors.Checked = true;
        }

           

        //function buildUpTriggerXML
        //this function constructs a XML formatted string which can be imported by GINA
        private string buildUpTriggerXml(string spellType, string getspellname, string getDescription1,
            string getcasting_time, string getmsg_cast_on_you,
            string getmsg_cast_on_other, string getmsg_wears_off, string getspelltype,
            string gettarget_type, string getspellicon, string stunTime, string getDuration1,
            string getClassList, string get_slots, string get_mana, string get_range, string get_resist)
            
        {
            // StringBuildider sb is where we're storing our builtUp XML, which is almost our final product
            StringBuilder sb = new StringBuilder();
            


            //if message when spell cast on another it shows "someone" is impaced
            //we replace the instance of "someone" with "{s1}" specific for the GINA Trigger format
            getmsg_cast_on_other = getmsg_cast_on_other.Replace("Someone 's", "{s1}'s");
            getmsg_cast_on_other = getmsg_cast_on_other.Replace("someone  's", "{s1}'s");
            getmsg_cast_on_other = getmsg_cast_on_other.Replace("Someone  ", "{s1} ");
            getmsg_cast_on_other = getmsg_cast_on_other.Replace("someone  ", "{s1} ");
            getmsg_cast_on_other = getmsg_cast_on_other.Replace( "Someone ", "{s1} ");
            getmsg_cast_on_other = getmsg_cast_on_other.Replace( "someone ", "{s1} ");
            getmsg_cast_on_other = getmsg_cast_on_other.Replace( "Someone", "{s1}")  ;
            getmsg_cast_on_other = getmsg_cast_on_other.Replace("someone", "{s1}")   ;

            //this tool/parsing doesn't diffirentiate if spell is a group spell or not, 
            //so we change all instances of "Group v2" or "Group v1" to "Single"
            gettarget_type = gettarget_type.Replace("Group v2", "Single");
            gettarget_type = gettarget_type.Replace("Group v1", "Single");


            //below attempts to translate the EQ original game icon to a color
            //this dictates the color of text/timer bars in GINA on a per trigger basis
            string calculated_getspellicon = "";
            switch (getspellicon)
            {
                case "B":
                case "F":
                case "H":
                case "S":
                case "U":
                    calculated_getspellicon = colorBFHSU;
                    break;
                case "A":
                case "J":
                case "R":
                    calculated_getspellicon = colorAJR;
                    break;
                case "C":
                case "D":
                case "I":
                    calculated_getspellicon = colorCDI;
                    break;
                case "N":
                case "P":
                case "V":
                    calculated_getspellicon = colorNPV;
                    break;
                case "G":
                case "M":
                    calculated_getspellicon = colorGM;
                    break;
                case "E":
                    calculated_getspellicon = colorE;
                    break;
                case "K":
                    calculated_getspellicon = colorK;
                    break;
                case "L":
                    calculated_getspellicon = colorL;
                    break;
                case "O":
                    calculated_getspellicon = colorO;
                    break;
                case "Q":
                    calculated_getspellicon = colorQ;
                    break;
                case "T":
                    calculated_getspellicon = colorT;
                    break;
            }

            
            sb.Append("<?xml version=" + Convert.ToChar(34) + "1.0" + Convert.ToChar(34) + " encoding=" + Convert.ToChar(34) + "utf-8" + Convert.ToChar(34) + "?>");

            sb.Append("<SharedData>");

            sb.Append("<TriggerGroups>");
            sb.Append("<TriggerGroup>");
            
            sb.Append("      <Name>Imported</Name>");
            sb.Append("      <Comments></Comments>");
            sb.Append("      <SelfCommented>False</SelfCommented>");
            sb.Append("      <GroupId>0</GroupId>");
            sb.Append("      <EnableByDefault>True</EnableByDefault>");
            
            sb.Append("<Triggers>");
            


            //#######################################################
            //#################### SPELL CASTING ####################
            //#######################################################
            sb.Append("<Trigger>");
            
            sb.Append("  <Name>(casting) " + getspellname + "</Name>");
            sb.Append("  <TriggerText>^You begin casting " + getspellname + ".$</TriggerText>");
            sb.Append("  <Comments>" + getDescription1 + " " + getClassList + " " + get_range + " " + get_mana + " " + get_slots + " " + get_resist + "</Comments>");
            sb.Append("  <EnableRegex>True</EnableRegex>");
            sb.Append("  <UseText>False</UseText>");
            sb.Append("  <DisplayText></DisplayText>");
            sb.Append("  <CopyToClipboard>False</CopyToClipboard>");
            sb.Append("  <ClipboardText></ClipboardText>");
            sb.Append("  <UseTextToVoice>False</UseTextToVoice>");
            sb.Append("  <InterruptSpeech>False</InterruptSpeech>");
            sb.Append("  <TextToVoiceText></TextToVoiceText>");
            sb.Append("  <PlayMediaFile>False</PlayMediaFile>");
            sb.Append("  <TimerType>Timer</TimerType>");
            sb.Append("  <TimerName>CASTING: " + getspellname + "</TimerName>");
            sb.Append("  <RestartBasedOnTimerName>True</RestartBasedOnTimerName>");

            // temp variable with which to do some math later
            double tempDoubleCastTime;

            if (Double.TryParse(getcasting_time, out tempDoubleCastTime)) { tempDoubleCastTime = (tempDoubleCastTime * 1000 - delayTime); }
            sb.Append("  <TimerMillisecondDuration>" + tempDoubleCastTime + "</TimerMillisecondDuration>");

            if (Double.TryParse(getcasting_time, out tempDoubleCastTime)) { tempDoubleCastTime = Math.Round((tempDoubleCastTime - delayTime) / 1000, 0); }
            sb.Append("  <TimerDuration>" + tempDoubleCastTime + "</TimerDuration>");
            sb.Append("  <TimerVisibleDuration>0</TimerVisibleDuration>");
            sb.Append("  <TimerStartBehavior>StartNewTimer</TimerStartBehavior>");

            sb.Append("  <TimerEndingTime>60</TimerEndingTime>");
            sb.Append("  <UseTimerEnding>False</UseTimerEnding>");
            sb.Append("  <UseTimerEnded>False</UseTimerEnded>");
            sb.Append("  <UseCounterResetTimer>False</UseCounterResetTimer>");
            sb.Append("  <CounterResetDuration>0</CounterResetDuration>");
            sb.Append("  <Category>CASTING-" + calculated_getspellicon + "</Category>");
            sb.Append("  <Modified>" + DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") + "</Modified>");
            sb.Append("  <UseFastCheck>True</UseFastCheck>");
            sb.Append("    <TimerEarlyEnders>");
            sb.Append("      <EarlyEnder>");
            sb.Append("        <EarlyEndText>^Your spell is interrupted.</EarlyEndText>");
            sb.Append("        <EnableRegex>True</EnableRegex>");
            sb.Append("      </EarlyEnder>");
            sb.Append("    </TimerEarlyEnders>");
            sb.Append("</Trigger>");


            //#######################################################
            //############### SPELL TARGET: SELF ####################
            //#######################################################

            double dblstunTime;
            Double.TryParse(stunTime, out dblstunTime);

            double tempDoubleDuration = 0;
            double.TryParse(getDuration1, out tempDoubleDuration);



            if (getmsg_cast_on_you.Trim() != "" && gettarget_type.ToUpper() != "PET")
            {
                sb.Append("<Trigger>");
                sb.Append("  <Name>(self) " + getspellname + "</Name>");
                sb.Append("  <TriggerText>^" + getmsg_cast_on_you + "$</TriggerText>");
                sb.Append("  <Comments>" + getDescription1 + " " + getClassList + " " + get_range + " " + get_mana + " " + get_slots + " " + get_resist + "</Comments>");
                sb.Append("  <EnableRegex>True</EnableRegex>");
                sb.Append("  <UseText>True</UseText>");
                sb.Append("  <CopyToClipboard>False</CopyToClipboard>");
                sb.Append("  <ClipboardText></ClipboardText>");

                if (checkBoxUseTextToSpeech.Checked)
                {
                    sb.Append("  <UseTextToVoice>True</UseTextToVoice>");
                }
                else
                {
                    sb.Append("  <UseTextToVoice>False</UseTextToVoice>");
                }

                sb.Append("  <InterruptSpeech>False</InterruptSpeech>");
                sb.Append("  <PlayMediaFile>False</PlayMediaFile>");
                sb.Append("  <RestartBasedOnTimerName>True</RestartBasedOnTimerName>");
                sb.Append("  <TimerVisibleDuration>0</TimerVisibleDuration>");
                sb.Append("  <TimerStartBehavior>RestartTimer</TimerStartBehavior>");
                sb.Append("  <UseCounterResetTimer>False</UseCounterResetTimer>");
                sb.Append("  <CounterResetDuration>0</CounterResetDuration>");


                sb.Append("  <DisplayText>" + getspellname + " -- {C}</DisplayText>");
                sb.Append("  <TextToVoiceText>" + getspellname + " -- {C}</TextToVoiceText>");
                if (getspelltype == "Detrimental")
                    {
                        //if its detrimental hitting us put it in the casting bar 
                        sb.Append("  <Category>CASTING-" + calculated_getspellicon + "</Category>");
                    }
                else
                    { 
                        
                        sb.Append("  <Category>SELF-" + calculated_getspellicon + "</Category>");
                    }


            if (dblstunTime > 0)
            {
                    sb.Append("  <TimerType>Timer</TimerType>");
                    // if its stun we dont want a timer end notice cause its too short duration
                    sb.Append("  <UseTimerEnding>False</UseTimerEnding>");
                    sb.Append("  <UseTimerEnded>False</UseTimerEnded>");
                    sb.Append("  <TimerEndingTime></TimerEndingTime>");
            }
            else if (tempDoubleDuration <= 0)
            {
                sb.Append("  <TimerType>NoTimer</TimerType>");
                sb.Append("  <UseTimerEnding>False</UseTimerEnding>");
                sb.Append("  <UseTimerEnded>False</UseTimerEnded>");
                sb.Append("  <TimerEndingTime></TimerEndingTime>");
            }
            else if (tempDoubleDuration <= 60)
            {
                sb.Append("  <TimerType>Timer</TimerType>");
                sb.Append("  <UseTimerEnding>True</UseTimerEnding>");
                sb.Append("  <UseTimerEnded>True</UseTimerEnded>");
                sb.Append("  <TimerEndingTime>12</TimerEndingTime>");
            }
            else if (tempDoubleDuration >= 60)
            {
                sb.Append("  <TimerType>Timer</TimerType>");
                sb.Append("  <UseTimerEnding>True</UseTimerEnding>");
                sb.Append("  <UseTimerEnded>True</UseTimerEnded>");
                sb.Append("  <TimerEndingTime>60</TimerEndingTime>");
            }
            else
            {
                MessageBox.Show("error: getDuration1 not = 0 and not > 0");
            }

            if (dblstunTime > 0)
            {
                sb.Append("  <TimerName>" + "Stun" + " {C}</TimerName>");
            }
            else
            {
                sb.Append("  <TimerName>" + getspellname + " {C}</TimerName>");
            }

            sb.Append("  <TimerMillisecondDuration>" + Math.Max(tempDoubleDuration * 1000 - delayTime, dblstunTime * 1000 - delayTime) + "</TimerMillisecondDuration>");
            sb.Append("  <TimerDuration>" + Math.Max(Math.Round(tempDoubleDuration - delayTime / 1000, 0), dblstunTime - delayTime / 1000) + "</TimerDuration>");
            sb.Append("  <TimerEndingTrigger>");
            sb.Append("    <UseText>True</UseText>");

            if (dblstunTime > 0 || stunTime != "")
            {
                sb.Append("    <DisplayText></DisplayText>");
                sb.Append("    <TextToVoiceText>Stun -- {C}</TextToVoiceText>");

            }
            else if (tempDoubleDuration < 60)
            {
                sb.Append("    <DisplayText>" + getspellname.ToUpper() + " 2 ticks remain {C}</DisplayText>");
                sb.Append("    <TextToVoiceText>" + getspellname + " 2 ticks remain {C}</TextToVoiceText>");
            }
            else
            {
                sb.Append("    <DisplayText>" + getspellname.ToUpper() + " 1 min remains {C}</DisplayText>");
                sb.Append("    <TextToVoiceText>" + getspellname + " 1 minute remains {C}</TextToVoiceText>");
            }

            if (checkBoxUseTextToSpeech.Checked)
            {
                sb.Append("    <UseTextToVoice>True</UseTextToVoice>");
            }
            else
            {
                sb.Append("    <UseTextToVoice>False</UseTextToVoice>");
            }

            sb.Append("    <InterruptSpeech>False</InterruptSpeech>");
            sb.Append("    <PlayMediaFile>False</PlayMediaFile>");
            sb.Append("  </TimerEndingTrigger>");
            sb.Append("  <TimerEndedTrigger>");
            sb.Append("    <UseText>True</UseText>");
            sb.Append("    <DisplayText>" + getspellname.ToUpper() + " DOWN {C}</DisplayText>");
            if (checkBoxUseTextToSpeech.Checked)
            {
                sb.Append("    <UseTextToVoice>True</UseTextToVoice>");
            }
            else
            {
                    sb.Append("    <UseTextToVoice>False</UseTextToVoice>");
                }   
            
            sb.Append("    <InterruptSpeech>False</InterruptSpeech>");
            sb.Append("    <TextToVoiceText>" + getspellname + " DOWN {C}</TextToVoiceText>");
            sb.Append("    <PlayMediaFile>False</PlayMediaFile>");
            sb.Append("  </TimerEndedTrigger>");
            sb.Append("  <TimerEarlyEnders>");
            sb.Append("  <EarlyEnder>");
            sb.Append("    <EarlyEndText>^" + getmsg_wears_off + "</EarlyEndText>");
            sb.Append("    <EnableRegex>True</EnableRegex>");
            sb.Append("  </EarlyEnder>");
            sb.Append("  <EarlyEnder>");
            sb.Append("    <EarlyEndText>^{C} end " + getspellname + " self</EarlyEndText>");
            sb.Append("    <EnableRegex>True</EnableRegex>");
            sb.Append("  </EarlyEnder>");
            sb.Append("  </TimerEarlyEnders>");
            sb.Append("  <Modified>" + DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") + "</Modified>");
            sb.Append("  <Usefastcheck>true</Usefastcheck>");
            sb.Append("</Trigger>");

            }


            //#######################################################
            //############### SPELL TARGET: OTHERS ##################
            //#######################################################

            if (gettarget_type.ToUpper() != "SELF" && getmsg_cast_on_other.Trim() != "")
            {

                sb.Append("<Trigger>");
                sb.Append("  <Name>" + getspellname + "</Name>");
                sb.Append("  <TriggerText>^" + getmsg_cast_on_other + "$</TriggerText>");
                sb.Append("  <Comments>" + getDescription1 + " " + getClassList + " " + get_range + " " + get_mana + " " + get_slots + " " + get_resist + "</Comments>");
                sb.Append("  <EnableRegex>True</EnableRegex>");
                sb.Append("  <UseText>True</UseText>");

                if (getspelltype != "Detrimental")
                {
                    sb.Append("  <DisplayText>" + getspellname + " -- {s1}</DisplayText>");
                    sb.Append("  <TextToVoiceText>" + getspellname + " -- {s1}</TextToVoiceText>");
                }
                else
                {
                    sb.Append("  <DisplayText>" + getspellname + " -- {s1}</DisplayText>");
                    sb.Append("  <TextToVoiceText>" + getspellname + " -- {s1}</TextToVoiceText>");
                }




                if (stunTime != "" && dblstunTime > 0)
                {
                    sb.Append("  <TimerType>Timer</TimerType>");
                    sb.Append("  <Usetimerending>False</Usetimerending>");
                    sb.Append("  <Usetimerended>True</Usetimerended>");
                }
                else if (tempDoubleDuration <= 0)
                {
                    sb.Append("  <TimerType>NoTimer</TimerType>");
                    sb.Append("  <Usetimerending>False</Usetimerending>");
                    sb.Append("  <Usetimerended>False</Usetimerended>");
                }
                else if (tempDoubleDuration <= 60)
                {
                    sb.Append("  <TimerType>Timer</TimerType>");
                    sb.Append("  <Usetimerending>False</Usetimerending>");
                    sb.Append("  <Usetimerended>True</Usetimerended>");
                }
                else if (tempDoubleDuration >= 60)
                {
                    sb.Append("  <TimerType>Timer</TimerType>");
                    sb.Append("  <Usetimerending>True</Usetimerending>");
                    sb.Append("  <Usetimerended>True</Usetimerended>");
                }
                else
                {
                    MessageBox.Show("Error: getDuration1/tempDouble not = 0 and not > 0");
                }


                if (stunTime != "" && dblstunTime > 0)
                {
                    sb.Append("  <TimerName>STUN -- {s1}</TimerName>");
                    sb.Append("  <TimerMillisecondDuration>" + Math.Max(dblstunTime * 1000 - delayTime, 0) + "</TimerMillisecondDuration>");
                    sb.Append("  <TimerDuration>" + Math.Max(dblstunTime - delayTime / 1000, 0) + "</TimerDuration>");
                }
                else
                {
                    sb.Append("  <TimerName>" + getspellname + " -- {s1}</TimerName>");
                    sb.Append("  <TimerMillisecondDuration>" + Math.Max(tempDoubleDuration * 1000 - delayTime, 0) + "</TimerMillisecondDuration>");
                    sb.Append("  <TimerDuration>" + Math.Max(tempDoubleDuration - delayTime / 1000, 0) + "</TimerDuration>");
                }

                if (stunTime != "" || dblstunTime < 60)
                {
                    sb.Append("  <TimerEndingTime>1</TimerEndingTime>");
                }
                else
                {
                    sb.Append("  <TimerEndingTime>60</TimerEndingTime>");
                }

                sb.Append("  <TimerEndingTrigger>");
                sb.Append("    <UseText>True</UseText>");

                if (stunTime != "")
                {
                    sb.Append("    <DisplayText>" + getspellname.ToUpper() + " -- 1 second {s1}</DisplayText>");
                    sb.Append("    <TextToVoiceText>" + getspellname.ToUpper() + " 1 second {s1}</TextToVoiceText>");
                }
                else
                {
                    sb.Append("    <DisplayText>" + getspellname.ToUpper() + " -- 1 min remains {s1}</DisplayText>");
                    sb.Append("    <TextToVoiceText>" + getspellname + " 1 minute remains {s1}</TextToVoiceText>");
                }

                if (checkBoxUseTextToSpeech.Checked)
                {
                    sb.Append("    <UseTextToVoice>True</UseTextToVoice>");
                }
                else
                {
                    sb.Append("    <UseTextToVoice>False</UseTextToVoice>");
                }

                sb.Append("    <InterruptSpeech>False</InterruptSpeech>");
                sb.Append("    <PlayMediaFile>False</PlayMediaFile>");
                sb.Append("  </TimerEndingTrigger>");
                sb.Append("  <TimerEndedTrigger>");
                sb.Append("    <UseText>True</UseText>");
                sb.Append("    <DisplayText>" + getspellname.ToUpper() + " -- DOWN -- {s1}</DisplayText>");
                if (checkBoxUseTextToSpeech.Checked)
                {
                    sb.Append("    <UseTextToVoice>True</UseTextToVoice>");
                }
                else
                {
                    sb.Append("    <UseTextToVoice>False</UseTextToVoice>");
                }
                sb.Append("    <InterruptSpeech>False</InterruptSpeech>");
                sb.Append("    <TextToVoiceText>" + getspellname + " DOWN {s1}</TextToVoiceText>");
                sb.Append("    <PlayMediaFile>False</PlayMediaFile>");
                sb.Append("  </TimerEndedTrigger>");

                sb.Append("    <TimerEarlyEnders>");
                sb.Append("      <EarlyEnder>");
                sb.Append("        <EarlyEndText>^{C} end " + getspellname + " {s1}|{C} stop " + getspellname + " {s1}</EarlyEndText>");
                sb.Append("        <EnableRegex>True</EnableRegex>");
                sb.Append("      </EarlyEnder>");
                sb.Append("      <EarlyEnder>");
                sb.Append("        <EarlyEndText>^{C} end " + getspellname + " ALL|{C} stop " + getspellname + " ALL</EarlyEndText>");
                sb.Append("        <EnableRegex>True</EnableRegex>");
                sb.Append("      </EarlyEnder>");
                sb.Append("      <EarlyEnder>");
                sb.Append("        <EarlyEndText>{s1} has been slain by|you have slain {s1}</EarlyEndText>");
                sb.Append("        <EnableRegex>True</EnableRegex>");
                sb.Append("      </EarlyEnder>");

                sb.Append("    </TimerEarlyEnders>");

                sb.Append("  <CopyToClipboard>False</CopyToClipboard>");
                sb.Append("  <ClipboardText></ClipboardText>");
                if (checkBoxUseTextToSpeech.Checked)
                {
                    sb.Append("  <UseTextToVoice>True</UseTextToVoice>");
                }
                else
                {
                    sb.Append("  <UseTextToVoice>False</UseTextToVoice>");
                }
                sb.Append("  <InterruptSpeech>False</InterruptSpeech>");
                sb.Append("  <PlayMediaFile>False</PlayMediaFile>");
                sb.Append("  <RestartBasedOnTimerName>True</RestartBasedOnTimerName>");
                sb.Append("  <TimerVisibleDuration>0</TimerVisibleDuration>");
                sb.Append("  <TimerStartBehavior>RestartTimer</TimerStartBehavior>");
                sb.Append("  <UseCounterResetTimer>False</UseCounterResetTimer>");
                sb.Append("  <CounterResetDuration>0</CounterResetDuration>");

                if (stunTime != "")
                {
                    sb.Append("  <Category>CASTING-" + calculated_getspellicon + "</Category>");
                }
                else if (getspelltype == "Detrimental")
                {
                    sb.Append("  <Category>OTHERDETRIMENTAL-" + calculated_getspellicon + "</Category>");
                }
                else
                {
                    sb.Append("  <Category>OTHER-" + calculated_getspellicon + "</Category>");
                }

                sb.Append("  <Modified>" + DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") + "</Modified>");
                sb.Append("  <UseFastCheck>True</UseFastCheck>");

                sb.Append("</Trigger>");

            }


            
            sb.Append("</Triggers>");
            sb.Append("</TriggerGroup>");
            sb.Append("</TriggerGroups>");
            sb.Append("</SharedData>");

            return sb.ToString();
        }


        
        private void buttonScrape_Click(object sender, EventArgs e)
        {
            string getspellname, getspellicon, getDescription1, getcasting_time, getDuration1, gettarget_type, getspell_type,
            getmsg_cast_on_you, getmsg_cast_on_other, getmsg_wears_off, stunTime, get_resist;
            string get_spellClassList, get_slots, get_mana, get_range;

            linkLabelProgressBar.Text = "";

            FailureList.Clear();
            SuccessList.Clear();
            
            
            //get these values from the ui that user input
            //double.TryParse(comboBoxDelay.SelectedItem.ToString(), out delayTime);
            //int.TryParse(comboBoxLevel.SelectedItem.ToString(), out characterLevel);

            //the below values occur in all the wiki pages and will be used to parse and obtain the values needed
            const string spellname = "| spellname =";
            const string spellicon = "| spellicon =";
            const string description1 = "| description =";
            const string casting_time = "| casting_time ="; // 12.00
            const string Duration1 = "| duration ="; // 1 hour 12 minutes
            const string target_type = "| target_type ="; // ''Self or Pet or Group
            const string spell_type = "| spell_type ="; // '' beneficial
            const string msg_cast_on_you = "| msg_cast_on_you ="; // ''You feel armored.
            const string msg_cast_on_other = "| msg_cast_on_other ="; // ''Blah
            const string msg_wears_off = "| msg_wears_off ="; // ''Your shielding fades.
            const string classesGoalpost = "| classes =";
            const string slots = "| slots =";
            const string mana = "| mana =";
            const string resist = "| resist =";
            const string range = "range ="; 
            const string rightGoalPost = "\n";



            //get all the text from the textBoxSpells textbox
            string alltext = textBoxSpells.Text;

            //replace all " " space with "_" underscore so that the url format is correct
            alltext = alltext.Trim();
            alltext = alltext.Replace(" ", "_");
            alltext = alltext.Replace("*", "");
            alltext = alltext.Replace("'", "%27");
            alltext = alltext.Replace("`", "%27");
            alltext = alltext.Replace("Enchant:", "Enchant");
            

            //replacing all "\n" makes it easier to split the data cleanly
            alltext = alltext.Replace("\n", "");

            //split all spells input by user in textbox into an array
            string[] allLines = alltext.Split('\r');
            int FailureCount = 0;
            int SuccessCount = 0;

            //progress bar
            progressBarSpellList.Maximum = allLines.Count();
            progressBarSpellList.Step = 1;
            progressBarSpellList.Value = 0;
            


            //loop through all spells input by user and begin to parse
            foreach (string Spell in allLines)
            {


                progressBarSpellList.Value++;
                
                //this is the URL from which we want to scrape data
                //the URL always this same format with the "Spell_Name" included in the url
                string p99url = "https://wiki.project1999.com/index.php?title=" + Spell.Trim() + "&action=edit";

                //scrape all html from the wiki page so that we can parse it
                WikiSource = getHtml(p99url);

                if (WikiSource.IndexOf(Spell.Trim()) < 0 || WikiSource.IndexOf("Login required") > 0 || WikiSource.IndexOf("| spellname") < 0)
                    //attempting to catch bad spell values input by user
                {
                    FailureCount++;
                    FailureList.Append(Spell.Trim().Replace("_"," ") + "\r");
                    continue;
                }

                //below is parsing data from the html using BETWEEN function
                getspellname = Between(WikiSource, spellname, rightGoalPost);
                getspellicon = Between(WikiSource, spellicon, rightGoalPost);
                getDescription1 = Between(WikiSource, description1, rightGoalPost);
                getcasting_time = Between(WikiSource, casting_time, rightGoalPost);
                getDuration1 = Between(WikiSource, Duration1, rightGoalPost);
                getspell_type = Between(WikiSource, spell_type, rightGoalPost);
                getmsg_cast_on_you = Between(WikiSource, msg_cast_on_you, rightGoalPost);
                getmsg_cast_on_other = Between(WikiSource, msg_cast_on_other, rightGoalPost);
                getmsg_wears_off = Between(WikiSource, msg_wears_off, rightGoalPost);
                gettarget_type = Between(WikiSource, target_type, rightGoalPost);
                get_spellClassList = Between(WikiSource, classesGoalpost, "| slots").Replace("\n","");
                get_slots = Between(WikiSource, slots, "| skill").Replace("\n","");
                get_mana = "Mana: " + Between(WikiSource, mana, rightGoalPost);
                get_range = "Range: " + Between(WikiSource, range, rightGoalPost);
                get_resist = "Resist: " + Between(WikiSource, resist, rightGoalPost);

                stunTime = "";
                
                if(WikiSource.IndexOf("Stun for ") > 0)
                {
                    stunTime = Between(WikiSource, "Stun for", " seconds");
                }

                if (stunTime != "")
                {
                    stunTime = durationCleanup(stunTime + "seconds");
                }
                if (getDuration1 != "")
                {
                    getDuration1 = durationCleanup(getDuration1);
                }




                // meat and taters to create XML 
                saveXML(buildUpTriggerXml("This is basically unused we dont have logic based on spell type", getspellname, getDescription1, getcasting_time,
                    getmsg_cast_on_you, getmsg_cast_on_other, getmsg_wears_off, getspell_type, gettarget_type, getspellicon, stunTime, getDuration1,
                    get_spellClassList, get_slots, get_mana, get_range, get_resist),getspellname);

                SuccessCount++;
                SuccessList.Append(Spell.Trim().Replace("_"," ") + "\r");
                

            }

            

            string doneMessage = "";
            SuccessList.Insert(0, "Successfully created GINA .gtp trigger import files for the following:\r\r");
            if (FailureCount == 0)
            {
                doneMessage = "\rCompleted. Created " + SuccessCount + " GINA trigger .gtp file(s)";
            }
            else if (FailureCount > 0)
            {
                doneMessage = "\rCompleted. Created " + SuccessCount + " GINA trigger .gtp file(s) with " + FailureCount + " failure(s)";
                FailureList.Insert(0, "Failed to create trigger import files for the following:\r\r");
                FailureList.Append("\r");
            }

            //labelProgressBarText.Text = doneMessage;
            linkLabelProgressBar.Text = doneMessage;




        }

        private void pictureBoxColor_Click(object sender, EventArgs e)
        {
            colorDialog1.AllowFullOpen = true;
            colorDialog1.Color = pictureBoxColor.BackColor;
            if (colorDialog1.ShowDialog(this) == DialogResult.OK)
            {
                pictureBoxColor.BackColor = colorDialog1.Color;
                switch (comboBoxColors.Text)
                {
                    case "B":
                    case "F":
                    case "H":
                    case "S":
                    case "U":
                        colorBFHSU = argbToHex(colorDialog1.Color);
                        break;
                    case "A":
                    case "J":
                    case "R":
                        colorAJR = argbToHex(colorDialog1.Color);
                        break;
                    case "C":
                    case "D":
                    case "I":
                        colorCDI = argbToHex(colorDialog1.Color);
                        break;
                    case "N":
                    case "P":
                    case "V":
                        colorNPV = argbToHex(colorDialog1.Color);
                        break;
                    case "G":
                    case "M":
                        colorGM = argbToHex(colorDialog1.Color);
                        break;
                    case "E":
                        colorE = argbToHex(colorDialog1.Color);
                        break;
                    case "K":
                        colorK = argbToHex(colorDialog1.Color);
                        break;
                    case "L":
                        colorL = argbToHex(colorDialog1.Color);
                        break;
                    case "O":
                        colorO = argbToHex(colorDialog1.Color);
                        break;
                    case "Q":
                        colorQ = argbToHex(colorDialog1.Color);
                        break;
                    case "T":
                        colorT = argbToHex(colorDialog1.Color);
                        break;
                }
            }
            
            
        }

        private void comboBoxColors_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
            pictureBoxIcons.Load("http://wiki.project1999.com/images/Spellicon_" + comboBoxColors.SelectedItem.ToString() + ".png");
            string spellColor = "";
            switch (comboBoxColors.Text)
            {
                case "B":
                case "F":
                case "H":
                case "S":
                case "U":
                    spellColor = colorBFHSU;
                    break;
                case "A":
                case "J":
                case "R":
                    spellColor = colorAJR;
                    break;
                case "C":
                case "D":
                case "I":
                    spellColor = colorCDI;
                    break;
                case "N":
                case "P":
                case "V":
                    spellColor = colorNPV;
                    break;
                case "G":
                case "M":
                    spellColor = colorGM;
                    break;
                case "E":
                    spellColor = colorE;
                    break;
                case "K":
                    spellColor = colorK;
                    break;
                case "L":
                    spellColor = colorL;
                    break;
                case "O":
                    spellColor = colorO;
                    break;
                case "Q":
                    spellColor = colorQ;
                    break;
                case "T":
                    spellColor = colorT;
                    break;
            }

            string tempColor = spellColor;
            tempColor = tempColor.Replace("#FF", "");
            tempColor = tempColor.Substring(tempColor.IndexOf("-") + 1);
            Color col = System.Drawing.ColorTranslator.FromHtml("#" + tempColor);
            pictureBoxColor.BackColor = col;

        }
        
        public void saveXML(string XML, string filename)
        {
            filename = filename.Replace(":", "");
            filename = filename.Replace("`", "");
            filename = filename.Replace("'", "");
            filename = filename.Replace("*", "");
            
            string PathToZip = Path.GetDirectoryName(Application.ExecutablePath) + "\\temp"; //"C:\\Users\\brett20\\Documents\\test"; 
            string zippedFilePath = Path.GetDirectoryName(Application.ExecutablePath) + "\\" + filename + ".zip";

            if (!Directory.Exists(PathToZip))
            {
                Directory.CreateDirectory(PathToZip);
            }
            if (!Directory.Exists(Path.GetDirectoryName(Application.ExecutablePath) + "\\GINAImportTriggers"))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(Application.ExecutablePath) + "\\GINAImportTriggers");
            }


            FileInfo fi = new FileInfo(PathToZip + "\\ShareData" + ".xml");
            if (fi.Exists)
            {
                fi.Delete();
            }
            fi = new FileInfo(zippedFilePath);
            if (fi.Exists)
            {
                fi.Delete();
            }
                        
            using (StreamWriter strm = File.CreateText(PathToZip + "\\ShareData.xml"))
            {
                strm.WriteLine(XML);
                strm.Close();
                strm.Dispose();
            }

            //zip it
            ZipFile.CreateFromDirectory(PathToZip, zippedFilePath);

            if (File.Exists(Path.GetDirectoryName(Application.ExecutablePath) + "\\GINAImportTriggers\\" + filename + ".gtp"))
            {
                File.Delete(Path.GetDirectoryName(Application.ExecutablePath) + "\\GINAImportTriggers\\" + filename + ".gtp");
            }
            //rename to .gtp GINA Trigger Package
            File.Move(zippedFilePath, Path.GetDirectoryName(Application.ExecutablePath) + "\\GINAImportTriggers\\" + filename + ".gtp");

            //cleanup and delete \\temp folder
            if (Directory.Exists(PathToZip))
            {
                File.Delete(PathToZip + "\\ShareData.xml");
                Directory.Delete(PathToZip);
            }


        }

        public string Between(string Text, string FirstString, string LastString)
        {
            string STR = Text;
            string STRFirst = FirstString;
            string STRLast = LastString;
            string FinalString;
            int Pos1 = STR.IndexOf(FirstString) + FirstString.Length + 1;
            int Pos2 = STR.IndexOf(LastString, STR.IndexOf(FirstString) + FirstString.Length);
            if (FirstString.Length == 0)
            {
                Pos1 = 0;
                Pos2 = STR.IndexOf(LastString);
            }
            FinalString = STR.Substring(Pos1, Pos2 - Pos1);
            

            return FinalString;
        }

        private string durationCleanup(string FullText)
        {
            ///logic to clean up different parsed durations
            ///example durations can look like:
            ///  "4.0 seconds up to level 55 }}" (Stun)
            ///  "| duration = 1.8 minutes @L8 to 2.5 minutes @L15"

            string hrs = "", mins= "", secs = "";
            string duration = FullText;

            //clean up for inconsistencies in p99 wiki so always shows "hours/minutes/seconds/ticks"
            duration = duration.Replace(" hour ", "hours ");
            duration = duration.Replace("min ", "mins ");
            duration = duration.Replace("mins ", "minutes ");
            duration = duration.Replace("sec ", "secs ");
            duration = duration.Replace("secs ", "seconds ");
            duration = duration.Replace("tick ", "ticks ");
            
            //remove space in front of time unit of measure for easier parsing
            duration = duration.Replace(" seconds", "seconds");
            duration = duration.Replace(" minutes", "minutes");
            duration = duration.Replace(" hours", "hours");
            duration = duration.Replace(" ticks", "ticks");

            if ((duration.Split('@').Length - 1) == 1)
            {
                // example: duration = "11ticks @L22"
                duration = duration.Replace(" ", "");
                duration = duration.Substring(0, duration.IndexOf("@"));
            }

            if ((duration.Split('@').Length - 1) == 1)
            {
                //example 1.8minutes @L8 to 2.5minutes @L15
                duration = duration.Replace("to ", ""); //remove for easier parsing
                duration = duration.Replace(" ", ",");
                //now looks like 1.8minutes,@L8,2.5minutes,@L15
                duration = duration.Replace("@L", "");
                //now looks like 1.8minutes,8,2.5minutes,15
                string[] durationStringSplit = duration.Split(',');
                //in our example durationStringSplit[0] = "1.8minutes",durationStringSplit[1] = "8"
                //durationStringSplit[2] = "2.5minutes",durationStringSplit[3] = "15"

                double lowerLevelBoundary = 0;
                double higherLevelBoundary = 0;
                double lowerTimeBoundary = 0;
                double higherTimeBoundary = 0;

                double.TryParse(durationStringSplit[1], out lowerLevelBoundary);
                double.TryParse(durationStringSplit[3], out higherLevelBoundary);

                double.TryParse(durationStringSplit[0].Replace("minutes",""), out lowerTimeBoundary);
                double.TryParse(durationStringSplit[2].Replace("minutes",""), out higherTimeBoundary);

                if (characterLevel >= higherLevelBoundary)
                {
                    duration = durationStringSplit[2];
                }
                else if (characterLevel <= lowerLevelBoundary)
                {
                    duration = durationStringSplit[0];
                }
                else
                {
                    duration = Math.Round((((higherTimeBoundary - lowerTimeBoundary) / (higherLevelBoundary - lowerLevelBoundary)) * (characterLevel - lowerLevelBoundary)) + lowerTimeBoundary, 1).ToString() + "minutes";
                }

            }

            string[] arrayDuration = duration.Split(' ');
            foreach (string parsedTimeValue in arrayDuration)
            {
                if (parsedTimeValue.IndexOf("hours") > 0)
                {
                    hrs = parsedTimeValue.Substring(0, parsedTimeValue.IndexOf("hours"));
                }
                if (parsedTimeValue.IndexOf("minutes") > 0)
                {
                    mins = parsedTimeValue.Substring(0, parsedTimeValue.IndexOf("minutes"));
                }
                if (parsedTimeValue.IndexOf("seconds") > 0)
                {
                    secs = parsedTimeValue.Substring(0, parsedTimeValue.IndexOf("seconds"));
                }
                if (parsedTimeValue.IndexOf("ticks") > 0)
                {
                    secs = parsedTimeValue.Substring(0, parsedTimeValue.IndexOf("ticks"));
                    double dblTemp = 0;
                    double.TryParse(secs, out dblTemp);
                    secs = (dblTemp * 6).ToString();
                }

            }

            double dHrs = 0, dSecs = 0, dMins = 0;
            double.TryParse(hrs, out dHrs);
            double.TryParse(mins, out dMins);
            double.TryParse(secs, out dSecs);

            
            return (dHrs * 3600 + dMins * 60 + dSecs).ToString();

           




        }

        private string getHtml(string pageUrl)
        {
            //function uses the passed in pageUrl and returns all the html for that page    
            using (WebClient client = new WebClient())
            {
                string htmlCode = client.DownloadString(pageUrl);
                return htmlCode;
            }
        }
        private static String argbToHex(System.Drawing.Color c)
        {
            return "#" + c.A.ToString("X2") + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }


        private void pictureBoxIcons_Click_1(object sender, EventArgs e)
        {
            if (pictureBoxAllIcons.Visible)
            {
                pictureBoxAllIcons.Visible = false;
            }
            else
            {
                pictureBoxAllIcons.Visible = true;
                if (Width < Properties.Resources.spellthemes.Width + 20)
                {
                    Width = Properties.Resources.spellthemes.Width + 20;
                }
                if (Height < Properties.Resources.spellthemes.Height + 20)
                {
                    Height = Properties.Resources.spellthemes.Height + 20;
                }
            }
        }

        private void pictureBoxAllIcons_Click_1(object sender, EventArgs e)
        {
            if (pictureBoxAllIcons.Visible)
            {
                pictureBoxAllIcons.Visible = false;
            }
        }

        private void progressBarSpellList_Click(object sender, EventArgs e)
        {

        }

        private void linkLabelProgressBar_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (FailureList.ToString() != "" || SuccessList.ToString() != "")
            {
                MessageBox.Show(FailureList.ToString() + SuccessList.ToString());
            }
        }

        private void comboBoxLevel_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int.TryParse(comboBoxLevel.Text, out characterLevel);
        }

        private void textBoxSpells_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxDelay_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            double.TryParse(comboBoxDelay.Text, out delayTime);
        }

        private void checkBoxUseTextToSpeech_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void buttonFixColorsInXmlFile_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Close your GINA application.\rThen click OK to reconcile GINA category colors.", "", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                linkLabelProgressBar.Text = "";
                SuccessList.Clear();
                FailureList.Clear();

                string ginaFilePath = ""; //example GINA File path: C:\Users\brett20\AppData\Local\GimaSoft\GINA\GINAConfig.xml

                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "Local") + "\\GimaSoft\\GINA\\GinaConfig.xml"))
                {
                    ginaFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "Local") + "\\GimaSoft\\GINA\\GinaConfig.xml";
                }
                else
                {
                    // If we know file path it exists use it dont prompt, other prompt to request file location
                    OpenFileDialog fp = new OpenFileDialog();
                    fp.Title = "Choose your GINA GINAConfig.xml file.";
                    fp.Filter = "XML Files (*.xml)|*.xml";
                    fp.FilterIndex = 1;
                    fp.Multiselect = false;
                    fp.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "Local") + "\\GimaSoft\\GINA";
                    if (fp.ShowDialog() == DialogResult.OK)
                    {
                        ginaFilePath = fp.FileName;
                    }
                }

                if (ginaFilePath != "")
                {

                    File.Copy(ginaFilePath, ginaFilePath.Replace("GinaConfig.xml", "Backup_GinaConfig_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xml"));

                    FailureList.Clear();
                    SuccessList.Clear();

                    XmlDocument doc = new XmlDocument();
                    doc.Load(ginaFilePath);
                    XmlNodeList xnlCategories = doc.SelectNodes("//Configuration/Categories/Category/Name");
                    int SuccessCounterTimerColor = 0;
                    int SuccessCounterFontColor = 0;

                    progressBarSpellList.Maximum = xnlCategories.Count;
                    progressBarSpellList.Value = 0;
                    progressBarSpellList.Step = 1;

                    foreach (XmlNode xnChildNodes in xnlCategories)
                    {
                        string tempArgbColor = xnChildNodes.InnerText.ToString();



                        XmlNode xn1 = doc.SelectSingleNode("/Configuration/Categories/Category[Name = '" + xnChildNodes.InnerText.ToString() + "']/TextStyle/FontColor");
                        XmlNode xn2 = doc.SelectSingleNode("/Configuration/Categories/Category[Name = '" + xnChildNodes.InnerText.ToString() + "']/TimerStyle/TimerBarColor");
                        XmlNode xn3 = doc.SelectSingleNode("/Configuration/Categories/Category[Name = '" + xnChildNodes.InnerText.ToString() + "']/TimerStyle/FontColor");
                        XmlNode xn4 = doc.SelectSingleNode("/Configuration/Categories/Category[Name = '" + xnChildNodes.InnerText.ToString() + "']/TimerOverlay");

                        //overlay
                        if (radioButtonUseThemeColors.Checked)
                        {
                            if (xnChildNodes.InnerText.IndexOf("#") >= 0 && tempArgbColor.IndexOf(xn1.InnerText.ToString()) < 0)
                            {
                                xn1.InnerText = (xnChildNodes.InnerText.Substring(xnChildNodes.InnerText.IndexOf("-#") + 1));
                                xn3.InnerText = "#FF000000";
                                SuccessCounterFontColor++;
                                SuccessList.Append("GINA Category: " + xnChildNodes.InnerText + " text color set to " + xn1.InnerText);
                            }
                            if (xnChildNodes.InnerText.IndexOf("#") >= 0 && tempArgbColor.IndexOf(xn2.InnerText.ToString()) < 0)
                            {
                                xn2.InnerText = (xnChildNodes.InnerText.Substring(xnChildNodes.InnerText.IndexOf("-#") + 1));
                                xn3.InnerText = "#FF000000";
                                xn4.InnerText = xnChildNodes.InnerText.Substring(0, xnChildNodes.InnerText.IndexOf("-"));
                                SuccessCounterTimerColor++;
                                SuccessList.Append(" timer bar color set to " + xn2.InnerText + " Overlay set to " + xn4.InnerText + "\r");
                            }
                        }
                        else
                        {
                            // these are GINA's default colors when you create a new category, yellow text, maroon timer bars
                            xn1.InnerText = "#FFFFFF00";
                            xn2.InnerText = "#FF800002";
                            xn3.InnerText = "#FFFFFF00";
                            xn4.InnerText = "Default";
                            SuccessList.Append("GINA Category: " + xnChildNodes.InnerText + ": Text color set to " + xn1.InnerText + "");
                            SuccessList.Append(" Timer Bar color set to " + xn2.InnerText + " Overlay set to " + xn4.InnerText + "\r");
                            SuccessCounterTimerColor++;
                            SuccessCounterFontColor++;
                        }

                        progressBarSpellList.Value++;
                    }

                    doc.Save(ginaFilePath);
                    linkLabelProgressBar.Text = "Updated: " + SuccessCounterFontColor + " category font color(s) and " + SuccessCounterTimerColor + " category timer bar color(s).\rReview 'Categories' colors in GINA";

                }
            }

        }
    }
}
