using System;

namespace to_do_list
{
    internal class Program
    {
        class Queue
        {
            private int size;
            private int head;
            private int tail;
            private string[] queue;

            public Queue(int size)
            {
                this.size = size;
                this.head = -1;
                this.tail = -1;
                this.queue = new string[size];
            }

            public bool isEmpty()
            {
                return (head < 0);
            }

            public bool isFull()
            {
                return (tail + 1 >= size);
            }

            public void enqueue(string value)
            {
                if (isFull()) throw new Exception("Queue is full!");
                if (isEmpty()) { head = 0; }
                tail++;
                queue[tail] = value;
            }

            public string dequeue()
            {
                if (isEmpty()) throw new Exception("Queue is empty!");
                string aux = queue[head];
                for (int i = 0; i < tail; i++)
                {
                    queue[i] = queue[i + 1];
                }
                queue[tail] = "";
                tail--;
                if (tail < 0) head = -1;
                return aux;
            }

            public void print()
            {
                if (isEmpty()) throw new Exception("Queue is empty!");
                for (int i = 0; i <= tail; i++)
                {
                    Console.WriteLine(queue[i]);
                }
            }

            public string getFront()
            {
                if (isEmpty()) throw new Exception("Queue is empty");
                return queue[head];
            }

            public string getTail()
            {
                if (isEmpty()) throw new Exception("Queue is empty!");
                return queue[tail];
            }
        }

        static void Main(string[] args)
        {
            try
            {
                Queue toDoList = new Queue(3);

                do
                {
                    Console.WriteLine("\nWelcome to To-Do-List");
                    Console.WriteLine("1. View Tasks");
                    Console.WriteLine("2. Add new Task");
                    Console.WriteLine("3. Finish a task");
                    Console.WriteLine("4. Exit");
                    Console.WriteLine("\nNote: Please add tasks in the order you want to complete them. The first task added will be the first one to be finished, and so on.\n");
                    Console.Write("Please select an option: ");
                    int option = int.Parse(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            Console.WriteLine();

                            Console.WriteLine("---- Tasks ----");

                            if (toDoList.isEmpty())
                            {
                                Console.WriteLine("To Do List is empty! Add new tasks to see the list.");
                                Console.WriteLine("Press any key to continue!");
                                Console.ReadKey();
                                break;
                            }

                            toDoList.print();
                            Console.WriteLine();
                            Console.WriteLine("Press any key to continue!");
                            Console.ReadKey();
                            break;

                        case 2:
                            Console.WriteLine();

                            if (toDoList.isFull())
                            {
                                Console.WriteLine("To Do List is full!");
                                Console.WriteLine("Press any key to continue!");
                                Console.ReadKey();
                                break;
                            }

                            Console.WriteLine("Write your task below");
                            string task = Console.ReadLine();

                            if (string.IsNullOrEmpty(task))
                            {
                                Console.WriteLine("Task can not be empty!");
                                Console.WriteLine("Press any key to continue!");
                                Console.ReadKey();
                                break;
                            }

                            toDoList.enqueue(task);
                            Console.WriteLine("New task has been added!");
                            Console.WriteLine("Press any key to continue!");
                            Console.ReadKey();

                            break;
                        case 3:
                            Console.WriteLine();

                            if (toDoList.isEmpty())
                            {
                                Console.WriteLine("To Do List is empty!");
                                Console.WriteLine("Press any key to continue!");
                                Console.ReadKey();
                                break;
                            }

                            Console.WriteLine("Finishing first added task...");

                            string aux = toDoList.dequeue();
                            Console.WriteLine($"'{aux}' task is removed from the list!");
                            Console.WriteLine("Press any key to continue!");
                            Console.ReadKey();

                            break;
                        case 4:
                            Console.WriteLine();
                            Console.WriteLine("Exiting application!");
                            return;
                        default:
                            Console.WriteLine();
                            Console.WriteLine("Invalid input! Please select an option between 1 - 4");
                            break;
                    }

                } while (true);
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
        }
    }
}
