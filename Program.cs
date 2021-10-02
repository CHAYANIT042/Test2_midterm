using System;
using System.Collections;
using System.Collections.Generic;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Information> people = new List<Information>(); //เก็บค่านักเรียนและพนักงาน
            Books book = new Books(); //สร้าง object ของหนังสือ
            int menu, type, id; //เก็บค่าตัวเลือก ประเภท และไอดีตามลำดับ
            string user, pass; //เก็บค่าชื่อผู้ใช้และรหัสผ่าน
            bool isDone = false; //เก็บค่าไว้ตรวจสอบถ้าโปรแกรมจบแล้ว
            string[] books; //เก็บค่าชื่อหนังสือทั้งหมด
            List<string> brrowBooksName = new List<string>(); //เก็บค่าชื่อหนังสือที่ยืม
            List<int> brrowBooksID = new List<int>(); //เก็บค่าไอดีหนังสือที่ยืม

            while (isDone == false) //ถ้าโปรแกรมจบแล้ว
            {
                Console.WriteLine("\nWelcome to Digital Library");
                Console.WriteLine("--------------------------");
                Console.WriteLine("1. Login\n2. Register"); //แสดงผลให้ผู้ใช้เลือก
                Console.Write("Select Menu: ");
                menu = Convert.ToInt32(Console.ReadLine()); //เก็บค่าที่ผู้ใช้เลือกไว้ใน menu
                Console.Clear(); //เคลียหน้าจอ

                if (menu == 1) //ถ้าเลือกเมนูที่ 1
                {
                    Console.WriteLine("Login Screen");
                    Console.WriteLine("--------------------------");
                    Console.Write("Select name: "); //แสดงผลให้ใส่ชื่อผู้ใช้
                    user = Convert.ToString(Console.ReadLine()); //เก็บชื่อผู้ใช้ใน userr
                    Console.Write("Select Password: "); //แสดงผลให้ใส่รหัสผ่าน
                    pass = Convert.ToString(Console.ReadLine()); //เก็บรหัสผ่านใน pass
                    Console.Clear(); //เคลียหน้าจอ

                    bool isFound = false; //กำหนดค่าเริ่มต้นให้ตรวจสอบว่าเจอชื่อผู้ใช้กับรหัสผ่านใหม
                    type = 0; //กำหนดค่าเริ่มต้นให้กับประเภท
                    id = 0; //กำหนดค่าเริ่มต้นให้กับ id
                    foreach (Information i in people) //วนลูปในลิส people เพื่อเช็ค
                    {
                        if (i.Username.Equals(user)) //ถ้าusernameตรงกัน
                        {
                            if (i.Password.Equals(pass)) //ถ้าpasswordตรงกัน
                            {
                                isFound = true; //กำหนดค่าตรวจสอบว่าเจอให้เป็น true
                                type = i.Type; //กำหนดประเภทเป็นประเภทของคนนั้นๆ
                                id = i.ID; //กำหนดไอดีเป็นไอดีของคนนั้นๆ
                                break; //ออกจากลูป
                            }
                        }
                    }
                    if(isFound == true) //ถ้าล็อคอินสำเร็จ
                    {
                        if(type == 1) //ถ้าเป็นนักเรียน
                        {
                            Console.WriteLine("Student Management");
                            Console.WriteLine("--------------------------");
                            Console.WriteLine("Name: " + user); //แสดงผล username
                            Console.WriteLine("Student ID: " + id); //แสดงผลไอดี
                            Console.WriteLine("--------------------------");
                            Console.WriteLine("1. Borrow Book");
                            Console.Write("Input Menu: "); //ให้ผู้ใช้เลือกเมนู
                            menu = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                            if (menu == 1) //ถ้าเลือกเมนูที่1
                            {
                                string input = "";
                                books = book.GetBookList(); //นำรายชื่อหนังสือทั้งหมดมาเก็บไว้ใน books
                                Console.WriteLine("Book List");
                                Console.WriteLine("--------------------------");
                                for (int i = 0; i < books.Length; i++) //วนลูปปเพื่อแสดงไอดีกับชื่อหนังสือ
                                {
                                    Console.WriteLine("Book ID: {0}\nBook name: {1}", i + 1, books[i]);
                                }

                                while(input != "exit") //วนลูปรับค่าไอดีหนังสือที่จะยืม ถ้ารับค่าเป็น exit จะหลุดออกจากลูป
                                {
                                    Console.Write("Input book ID: ");
                                    input = Convert.ToString(Console.ReadLine());
                                    if(input != "exit") //ถ้าผู้ใช้ใส่ไอดีหนังสือ
                                    {
                                        int bookID = Convert.ToInt32(input); //นำค่าที่รับมา convert เป็น int แล้วกำหนดค่าไปที่ bookID
                                        brrowBooksName.Add(books[bookID - 1]); //เพิ่มชื่อหนังสือจากลิส books ที่ตำแหน่งที่ผู้ใช้ใส่
                                        brrowBooksID.Add(bookID); //เพิ่มไอดีหนังสือลงในลิส
                                    }
                                }

                                Console.Clear();
                                Console.WriteLine("Student name: " + user); //แสดงผล username
                                Console.WriteLine("Student ID: " + id); //แสดงผลไอดี
                                Console.WriteLine("Book List");
                                Console.WriteLine("--------------------------");
                                for (int i = 0; i < brrowBooksName.Count; i++) //วนลูปแสดงผลหนังสือที่ยืมไป
                                {
                                    Console.WriteLine("Book ID: {0}\nBook name: {1}", brrowBooksID[i], brrowBooksName[i]); //แสดงผลไอดีและชื่อหนังสือนั้นๆ
                                }
                            }
                        }
                        else //ถ้าเป็นพนักงาน
                        {
                            Console.WriteLine("Employee Management");
                            Console.WriteLine("--------------------------");
                            Console.WriteLine("Name: "+user); //แสดงผล username
                            Console.WriteLine("Employee ID: "+id); //แสดงผลไอดี
                            Console.WriteLine("--------------------------");
                            Console.WriteLine("1. Get List Books");
                            Console.Write("Input Menu: "); //ให้ผู้ใช้เลือกเมนู
                            menu = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();

                            if (menu == 1) //ถ้าเลือกเมนูที่ 1
                            {
                                books = book.GetBookList();
                                Console.WriteLine("Book List");
                                Console.WriteLine("--------------------------");
                                for (int i = 0; i < books.Length; i++) //วนลูปแสดงไอดีและชื่อหนังสือ
                                {
                                    Console.WriteLine("Book ID: {0}\nBook name: {1}", i+1, books[i]); //แสดงผลไอดีแลัชื่อหนังสือนั้นๆ
                                }
                            }
                        }
                    }
                }
                else if(menu == 2) //ถ้าเลือกลงทะเบียน
                {
                    Console.WriteLine("Register new Person");
                    Console.WriteLine("--------------------------");
                    Console.Write("Select name: ");
                    user = Convert.ToString(Console.ReadLine()); //ใส่ชื่อที่ผู้ใช่ใส่ใน user
                    Console.Write("Select Password: ");
                    pass = Convert.ToString(Console.ReadLine()); //เก็บรหัสผ่านที่ผู้ใช้ใส่ไว้ใน pass
                    Console.Write("Input User Type 1 = Student, 2 = Employee: ");
                    type = Convert.ToInt32(Console.ReadLine()); //เก็บค่าประเภทที่ผู้ใช้ใส่ไว้ใน type
                    if (type == 1) //ถ้าผู้ใช้เลือกประเภทที่ 1
                    {
                        Console.Write("Student ID: "); //ให้ใส่ไอดีของนักเรียน
                    }
                    else //ถ้าผู้ใช้เลือกประเภทที่ 2
                    {
                        Console.Write("Employee ID: "); //ให้ใส่ไอดีของพนักงาน
                    }
                    id = Convert.ToInt32(Console.ReadLine()); //นำค่าไอดีที่รับมาเก็บไว้ในตัวแปร id
                    Information newPerson = new Information(user, pass, type, id); //สร้าง attribute ของคนที่ลงทะเบียนใหม่ขึ้นมา
                    people.Add(newPerson); //เพิ่มลงในลิส
                    Console.Clear();
                }
                else //ถ้าผู้ใช้ใส่อย่างอื่น
                {
                    isDone = true; //กำหนดค่าจบการทำงานเป็น true
                }
            }
        }
    }
}
