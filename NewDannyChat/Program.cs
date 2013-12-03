using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDannyChat
{
    public class program
    {
        static WordandCount sublistelement;
        static List<WordandCount> SubsequentList;
        static StartWord firstword;
        static string originword = "";
        
        
        static List<StartWord> startwordlist = new List<StartWord>();
        
       

       static void ReadSentence()
        {

         

            
            bool foundmatch = false;// use a bool to find a matching word in the list
            
            string inputline = Console.ReadLine();//read in a line

            string[] arrayofwords = inputline.Split(' ');// split it in to an array of strings

           
           

           
            for ( int i = 0; i < arrayofwords.Length; i++)//count through the main list
            {
                foundmatch = false;
                

                for (int j = 0; j < startwordlist.Count; j++)//for every element of the sentence that has been read in
                {                                            //check if there is a match with words in the list
                   if(foundmatch==false)
                   { 

                                if (startwordlist[j].Start == arrayofwords[i].Trim())//if there is a match check the subsequent list of words
                                { //start if else 
                                    foundmatch = true;
                                    if (i == 0)// are we checking a sentence startword? if true set Amstart to true
                                    {
                                        startwordlist[j].Amstart = true;
                                    }
                                    if (i + 1 < arrayofwords.Length)//only check subsequent list if there are any words to follow
                                    {
                                        bool foundsublistentry = false;
                                        for (int k = 0; k < startwordlist[j].Nextword.Count(); k++)//******THIS IS WRONG*********
                                        {

                                            if (startwordlist[j].Nextword[k].Usedword == arrayofwords[i + 1].Trim())
                                            {
                                                startwordlist[j].Nextword[k].Countused++;

                                                foundsublistentry = true;

                                    
                                                break;
                                            }//endif

                                        }//end for

                                        if ((i < arrayofwords.Length - 1) & foundsublistentry == false)
                                        {
                                            sublistelement = new WordandCount();
                                            startwordlist[j].Nextword.Add(sublistelement);
                                            sublistelement.Usedword = arrayofwords[i + 1].Trim();
                                            sublistelement.Countused=1;
                                         }//endif
                                    }
                                }//end if
                       }
                 } //end for

                if (foundmatch == false)
                {
                    firstword = new StartWord();
                    
                    startwordlist.Add(firstword);
                    firstword.Start = arrayofwords[i].Trim();
                    if (i == 0)// are we checking a sentence startword? if true set Amstart to true
                    {
                        firstword.Amstart = true;
                    }
                    if (i < (arrayofwords.Length - 1))//when new word created givve it a follow word
                    {
                        sublistelement = new WordandCount();
                        SubsequentList = new List<WordandCount>();

                        SubsequentList.Add(sublistelement);
                        firstword.Nextword = SubsequentList;
                        sublistelement.Usedword = arrayofwords[i + 1].Trim();
                        sublistelement.Countused = 1;


                    }
                    else
                    {
                        firstword.AmEnd = true;
                    }//end if

                }//end if else
            }//end for


           //pick a random word from the list, check if it has been flaged as a start word, if true set it as the origin word
            
            
            WriteSentence(arrayofwords);
            ReadSentence();
    
        }//end static




        static void WriteSentence(string[] sentence)
        {
            List<string> fullsentence = new List<string>();// make a new list of words that are to be used to reply
            Boolean isaStart = false;
            Boolean carryon = true;// a boolean to decide wheter to end the return sentence

            while (isaStart == false)/****** SOMETHING WRONG *********/
            {
                Random num = new Random();
                int rangom = num.Next(sentence.Length);//pick a random number from 0-(length of sentence-1)
                originword = sentence[rangom];// pick a random word from the line that has been read in
                for (int stopcheck = 0; stopcheck < startwordlist.Count; stopcheck++)
                {
                    if (originword == startwordlist[stopcheck].Start)//look through the startlist to find a word that has been flaged as astart word.
                    {
                        if (startwordlist[stopcheck].Amstart == true)//when origin word has been located, check to see if it has been flaged as a word to start a sentence
                        {
                            isaStart = true;//If the origin word is ok to use as a start word, exit the loop
                            stopcheck = startwordlist.Count + 1;
                            fullsentence.Add(originword);//put a word into the reply
                            
                        }
                    }
                }
            }
            
        for (int ja = 0; ja < 15; ja++)//make a loop with a count of 15, this ensures that Danny won't keep rambling on..
        {
                for (int j = 0; j < startwordlist.Count; j++)/**********get back here after origin word is changed*************/
                {
                    if (startwordlist[j].Start == originword)//look through list for the originword word
                    {
                        if (ja > 6 && startwordlist[j].AmEnd == true)//if the sentence if 6 words long it will start looking for an end word
                        {

                            Random brekran = new Random();
                            int nowOut = brekran.Next(0, 4);//if an end word is found it is 70/30 to end the sentence
                            if (nowOut < 3)
                            {
                                j = startwordlist.Count + 1;
                                ja = 16;
                                carryon = false;
                            }

                        }
                        if (carryon == true && startwordlist[j].Nextword.Count>0)// if endword is not chosen pick a nextword
                        {
                                int highest = 0;
                                int pickoriginword = 0;
                                for (int ocount = 0; ocount < startwordlist[j].Nextword.Count; ocount++)
                                {
                                    if (highest < startwordlist[j].Nextword[ocount].Countused)// picks the follow word that used most
                                    {
                                        highest = startwordlist[j].Nextword[ocount].Countused;
                                        pickoriginword = ocount;
                                    }
                                    else if (highest == startwordlist[j].Nextword[ocount].Countused)// if there are words that get used equally it picks one at random to proceed.
                                    {
                                        Random numchange = new Random();
                                        int ranchange = numchange.Next(1, 3);
                                        if (ranchange < 2)
                                        {
                                            pickoriginword = ocount;
                                        }
                                    }

                                }


                               /* Random num = new Random();
                                int pickoriginword = startwordlist[j].Nextword.Count;
                                 pickoriginword = num.Next(0,pickoriginword);*/
                                originword = startwordlist[j].Nextword[pickoriginword].Usedword;
                                fullsentence.Add(originword);//put a word into the reply
                                
                                j = startwordlist.Count+1;
                            
                        }
                    }
                }
                   
                  
            } //when loop of 15 has filled the array or carryon == false, print.
            Console.WriteLine();
            for (int uy = 0; uy < fullsentence.Count; uy++)
            {
                
                
                    Console.Write(fullsentence[uy] + " ");
                
                if (uy > 14)
                {
                    Console.Write(".... sorry,  I may be rambling. You say something");
                    uy = fullsentence.Count + 1;
                }
            }
            Console.WriteLine(". ");

        }//end static

        static void Loadtextfile(string filename)
        {

        }




        static void Main(string[] args)
        {
            Console.WriteLine("\tPlease select an Option and press enter:\n");
            Console.WriteLine("\t\t1.\tLoad a random textfile to start");
            Console.WriteLine("\t\t2.\tTeach me to speak from scratch with an option to save\n\t\t\twords used in our conversation");
            Console.WriteLine("\t\t3.\tExit the program");
            //Makechoice();
            ReadSentence();
            
            
           
            
        }
       
        


    }//end public
}//end program
