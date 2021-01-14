using System;

namespace love
{
    /* This console application returns how many days, hours, minutes or seconds user's love lasts,
     from the date which the user input to current date. */
    class Date
    {
        public int day;
        public int month;
        public int year;
        public int dy;
        public int mn;
        public int yy;


        /* Constructor
           day - the day of the date that the user input
           month - the month of the date that the user input
           year - the year of the date that the user input

           dy - the day of the current date
           mn - the month of the current date
           yy - the year of the carrent date
        */
        public Date( int d, int m, int y)
        {
            DateTime todaysDate = DateTime.Now.Date;
            dy = todaysDate.Day;
            mn = todaysDate.Month;
            yy = todaysDate.Year;

            day = d;
            month = m;
            year = y;
        }

        //The method that checks if the year which is input is leap
        public bool LeapYear(int year)
        {
            if (year % 400 == 0)
            {
                return true;
            }
            else if (year % 100 == 0)
            {
                return false;
            }
            else if (year % 4 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
                
        }

        //The method that returns how many days user's love lasts
        public int InDays(int day, int month, int year)
        {
            //The variable that stores the number of days user's love lasts
            int days = 0;
            //If the month and the year of the date that user input are equal to the month and the year of the current date
            if (month == mn && year == yy)
            {
                days += dy - day + 1;
            }
            //If the month and the year of the date that user input are not equal to the month and the year of the current date
            else
            {
                //This part of the code counts the number od days to the end of the month of the date that the user input
                switch (month)
                {
                    case 1: case 3: case 5: case 7: case 8: case 10: case 12:
                        days += 31 - day + 1;
                        break;
                    case 2:
                        if (LeapYear(year) == true)
                        {
                            days += 29 - day + 1;
                        }
                        else
                        {
                            days += 28 - day + 1;
                        }
                        break;
                    case 4: case 6: case 9: case 11:
                        days += 30 - day + 1 ;
                        break;
                }

                /* This part of the code counts the number of days from the next month of the date that  the user input
                to the end of the year that the user input */
                for (int i = month + 1; i <= 12; i++)
                {
                    switch (i)
                    {
                        case 1: case 3: case 5: case 7: case 8: case 10: case 12:
                            days += 31;
                            break;
                        case 2:
                            if (LeapYear(year) == true)
                            {
                                days += 29;
                            }
                            else
                            {
                                days += 28;
                            }
                            break;
                        case 4: case 6: case 9: case 11:
                            days += 30;
                            break;
                    }
                }

                /* This part of the code counts the number of days from the next year of the date that the user input 
                to the current year */
                for (int i = year + 1; i < yy; i++)
                {
                    if (LeapYear(i) == true)
                    {
                        days += 366;
                    }
                    else
                    {
                        days += 365;
                    }
                }
                
                //This part of the code counts the number of days in the current year
                //Adds the number of days in the current month
                days += dy;
               
                //Counts the number of days from the current month to the begining of the current year
                for (int i = mn - 1; i >= 1; i++)
                {
                    switch (i)
                    {
                        case 1: case 3: case 5: case 7: case 8: case 10: case 12:
                            days += 31;
                            break;
                        case 2:
                            if (LeapYear(year) == true)
                            {
                                days += 29;
                            }
                            else
                            {
                                days += 28;
                            }
                            break;
                        case 4: case 6: case 9: case 11:
                            days += 30;
                            break;
                    }
                }
                
            }      
            return days;
        }


        //The method that returns how many hours user's love lasts
        public int inHours(int day, int month, int year)
        {
            int days = InDays(day, month, year);
            return days * 24;
        }


        //The method that returns how many minutes user's love lasts
        public int inMinutes(int day, int month, int year)
        {
            int hours = inHours(day, month, year);
            return hours * 60;
        }


        //The method that returns how many seconds user's love lasts
        public int inSeconds(int day, int month, int year)
        {
            int minutes = inMinutes(day, month, year);
            return minutes * 60;
        }

        static void Main(string[] args)
        {
            //The date that the user input
            Console.WriteLine("Enter the date (E.g 01.06.2010.): ");
            string date = Console.ReadLine();
            
            //The day, the month and the year of the date that the user input
            int day = Convert.ToInt32(date.Substring(0, 2));
            int month = Convert.ToInt32(date.Substring(3, 2));
            int year = Convert.ToInt32(date.Substring(6, 4));


            //The day, the month and the year of the current date
            DateTime todaysDate = DateTime.Now.Date;
            int dy = todaysDate.Day;
            int mn = todaysDate.Month;
            int yy = todaysDate.Year;

            //The object of the Class Date
            Date myDate = new Date(day, month, year);
            Console.WriteLine("Your love lasts:\n" + myDate.InDays(day, month, year) + " days, \n" +
                                                    myDate.inHours(day,month,year) + " hours, \n" +
                                                    myDate.inMinutes(day, month, year) + " minutes, \n" +
                                                    myDate.inSeconds(day, month, year) + " seconds. \n");

        }


    }
}
