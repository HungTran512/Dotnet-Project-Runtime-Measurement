using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Linq;

namespace Gritango
{
    class Program
    {
        public static void Main(string[] args){   
            var watch = new System.Diagnostics.Stopwatch();
            ///replace this with one/multiple resume and add a loop to each find skill function
            string resume = "Software development professional with experience in developing and designing web applications using HTML, CSS, JavaScript, Node.js, React Native, Angular, Dart, Flutter and React. Adept at developing and deploying complex backend systems, web services and databases, using both MEAN and MERN stack\nSoftware development professional with experience in developing and designing web applications using HTML, CSS, JavaScript,Node.js, React Native, Angular,, Dart, Flutter and React. Adept at developing and deploying complex backend systems, web services and databases, using both MEAN and MERN stack.Software development professional with experience in developing and designing web applications using HTML, CSS, JavaScript,Node.js, React Native, Angular,, Dart, Flutter and React. Adept at developing and deploying complex backend systems, web services and databases, using both MEAN and MERN stack.Software development professional with experience in developing and designing web applications using HTML, CSS, JavaScript,Node.js, React Native, Angular,, Dart, Flutter and React. Adept at developing and deploying complex backend systems, web services and databases, using both MEAN and MERN stack.Software development professional with experience in developing and designing web applications using HTML, CSS, JavaScript,Node.js, React Native, Angular,, Dart, Flutter and React. Adept at developing and deploying complex backend systems, web services and databases, using both MEAN and MERN stack.Software development professional with experience in developing and designing web applications using HTML, CSS, JavaScript,Node.js, React Native, Angular,, Dart, Flutter and React. Adept at developing and deploying complex backend systems, web services and databases, using both MEAN and MERN stack.Software development professional with experience in developing and designing web applications using HTML, CSS, JavaScript,Node.js, React Native, Angular,, Dart, Flutter and React. Adept at developing and deploying complex backend systems, web services and databases, using both MEAN and MERN stack.Software development professional with experience in developing and designing web applications using HTML, CSS, JavaScript,Node.js, React Native, Angular,, Dart, Flutter and React. Adept at developing and deploying complex backend systems, web services and databases, using both MEAN and MERN stack.";

            //start watch
            watch.Start();

            string[] normal = FindSkillsinResume(resume);

            // Console.WriteLine("\nSkills found: ");
            // foreach (string skill in normal){
            //     Console.WriteLine(skill);
            // }
            watch.Stop();

            Console.WriteLine("Without performance improvements");
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

            watch.Restart();
            string[] improved = FindSkillsinResumeImproved(resume);
            // Console.WriteLine("\nSkills found (improved version): ");
            // foreach(string skill in improved){
            //     Console.WriteLine(skill);
            // }
            watch.Stop();
            Console.WriteLine("With performance improvements");
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

        }

        public static string[] FindSkillsinResume(string resume){
            //just a list of tring that you want to filtered from a resume
            string[] skills = {"HTML", "CSS","JavaScript", "Node.js", "Angular", "Dart", "Python", "Java","C#", "ASP.NET", "Flutter" };
            var foundSkills = new HashSet<string>();
            foreach (string keyword in skills){
                if(resume.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0){
                    foundSkills.Add(keyword);
                }
            }
            return foundSkills.ToArray();
        }
        //function improvement using simple regex search
        public static string [] FindSkillsinResumeImproved(string resume){
            //same list
            string[] skills = {"HTML", "CSS","JavaScript", "Node.js", "Angular", "Dart", "Python", "Java","C#", "ASP.NET", "Flutter" };
            string pattern = string.Join("|", skills.Select(Regex.Escape));
            
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

            var foundSkills = new HashSet<string>();

            foreach (Match match in regex.Matches(resume)){
                string skill = match.Value;
                bool added = foundSkills.Add(skill);
            }

            return foundSkills.ToArray();
        }
    }
}
