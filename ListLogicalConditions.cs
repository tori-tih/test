using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR4_VAR9_TIKHONOVA_MIVS
{
    class ListLogicalConditions
    {
        LogicalCondition head;
        public LogicalCondition Head
        {
            get
            {
                return head;
            }
            set
            {
                head = value;
            }
        }
        public ListLogicalConditions()
        {
            head = new LogicalCondition();
            head.Next = head;
            head.Prev = head;
        }

        public void AddFirst(bool log, ListEvents events, string name, Image start)
        {
           LogicalCondition p = new LogicalCondition(log, events, name, head.Next, head,start);
            head.Next.Prev = p;
            head.Next = p;
            

        }
        public ListEvents GetEventDay()
        {
            return head.Prev.Events;
        }
        public string GetWether()
        {
           return head.Next.Name;
        }
       public Image GetWetherChoice()
        {
            return head.Next.Start;
        }
        public Image GetStart()
        {
            return head.Prev.Start;
        }
        public void DeleteAll()
        {
            head.Next = head.Next.Next;
            head.Next = head.Next.Next;
        }
        public void Delete(int pos)
        {
            if (pos >= 0)
            {
                int i = 0;
                LogicalCondition p = head.Next;
                while ((p.Next.Next != head) && (i < pos - 1))
                {
                    p = p.Next;
                    i++;
                }
                if (i == pos - 1)
                {
                    p.Next = p.Next.Next;
                    p.Next.Prev = p;
                }

            }
        }

        public void DeleteFirst()
        {
            if (head.Next != null)
            {
                head.Next = head.Next.Next;
            }
        }

        public void DeleteLast()
        {
            if ((head.Next != null) && (head.Next.Next != null))
            {
                int i = 0;
                LogicalCondition p = head.Next;
                while (p.Next.Next != head)
                {
                    p = p.Next;
                    i++;
                }
                p.Next = p.Next.Next;
                p.Next.Prev = p;
            }
            else
            {
                head.Next = null;
            }
        }

        public void Print(ListBox listBox)
        {
            LogicalCondition p = head.Next;
            while (p != head)
            {
                listBox.Items.Add("Логическое условие:");
                listBox.Items.Add(p.Name);
                listBox.Items.Add(p.Log.ToString());
                listBox.Items.Add("Множество событий:");
                p.Events.Print(listBox);
                listBox.Items.Add(" ");
                p = p.Next;
            }
        }

    }
    class LogicalCondition
    {
        private ListEvents events;
        private bool log;
        private string name;
        private LogicalCondition next;
        private LogicalCondition prev;
        private Image start;

        public Image Start
        {
            get
            {
                return start;
            }
            set
            {
                start = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public ListEvents Events
        {
            get
            {
                return events;
            }
            set
            {
                events = value;
            }
        }

        public bool Log
        {
            get
            {
                return log;
            }
            set
            {
                log = value;
            }
        }

        public LogicalCondition Next
        {
            get
            {
                return next;
            }
            set
            {
                next = value;
            }
        }
        public LogicalCondition Prev
        {
            get
            {
                return prev;
            }
            set
            {
                prev = value;
            }
        }
        public LogicalCondition()
        {
        }
        public LogicalCondition(bool log, ListEvents events, string name, Image start)
        {
            Name = name;
            Log = log;
            Events = events;
            Start = start;
        }
        public LogicalCondition(bool log, ListEvents events, string name, LogicalCondition next, LogicalCondition prev, Image start)
        {
            Name = name;
            Log = log;
            Events = events;
            Next = next;
            Prev = prev;
            Start = start;
        }
    }
}
