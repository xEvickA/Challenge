using System.Text.Json;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System;

namespace app{
        class Group{
                private readonly int _id;
                public Group(int id){
                        _id = id;
                }
                public int GetId(){
                        return _id;
                }
        }

        class Employee{
                private readonly int _id;
                public int group_id;
                
                public Employee(int id){
                        _id = id;
                }
                public void SetGroupId(int id){
                        group_id = id;
                }
                public int GetGroupId(){
                        return group_id;
                }

                public int GetId(){
                        return _id;
                }
        }

        public class Answer{
                public int employeeId { get; set; }
                public int groupId { get; set; }
                public DateTime answeredOn { get; set; }
                public float answer1 { get; set; }
                public float answer2 { get; set; }
                public float answer3 { get; set; }
                public float answer4 { get; set; }
                public float answer5 { get; set; }

                public Answer() { }

                public Answer(int employee_Id, int group_Id, DateTime answered_On, float ans1, float ans2, float ans3, float ans4, float ans5)
                {
                        employeeId = employee_Id;
                        groupId = group_Id;
                        answeredOn = answered_On;
                        answer1 = ans1;
                        answer2 = ans2;
                        answer3 = ans3;
                        answer4 = ans4;
                        answer5 = ans5;
                }
        }
        
        class Program{
                public static List<Answer> from_Js_get_answers(){
                        string json = File.ReadAllText("answers.json");
                        List<Answer> ans = JsonConvert.DeserializeObject<List<Answer>>(json);
                        return ans;
                }

                public float group_score_in_month(int group_id, int month, int year, List<Answer> answers){
                        float sum = 0;
                        int counter = 0;
                        for(int i = 0; i < answers.Count; i++){
                                Answer a = answers[i];
                                if(a.groupId == group_id && a.answeredOn.Month == month && a.answeredOn.Year == year){
                                        sum += a.answer1;
                                        sum += a.answer2;
                                        sum += a.answer3;
                                        sum += a.answer4;
                                        sum += a.answer5;
                                        counter += 5;
                                }
                        }
                        Console.WriteLine(counter.ToString());
                        return sum/counter;
                }
                static void Main(string[] args)
                {
                        Program p = new Program();
                        List<Answer> answers = from_Js_get_answers();
                        float pom = p.group_score_in_month(3, 3, 2021, answers);
                        Console.WriteLine(pom.ToString());
                }
        }
}