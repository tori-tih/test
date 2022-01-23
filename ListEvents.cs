using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR4_VAR9_TIKHONOVA_MIVS
{
    class ListEvents
    {
        Event head;
        public Event Head
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

        public ListEvents()
        {
            head = new Event();
            head.Next = head;
            head.Prev = head;
        }
        public string Get(int pos)
        {
            string info = "";
            if (pos >= 0)
            {
                int i = 0;
                Event p = head.Next;
                while ((p.Next.Next != head) && (i < pos - 1))
                {
                    p = p.Next;
                    i++;
                }
                if (i == pos - 1)
                {
                    info = p.Next.NameEvent;
                }

            }
            return info;
        }
        public void AddFirst(string infoVal, int time, Image picture)
        {
            Event p = new Event(infoVal, head.Next, head, time, picture);
            head.Next.Prev = p;
            head.Next = p;
        }
        
        //public void AddAfter(int pos, string info)
        //{
        //    if (pos >= 0)
        //    {
        //        int i = 0;
        //        Event p = head.Next;
        //        while ((p.Next != head) && (i < pos))
        //        {
        //            p = p.Next;
        //            i++;
        //        }
        //        Event k = new Event(info, p, p.Next);
        //        p.Next = k;
        //        k.Next.Prev = k;
        //    }
        //}


        public void Delete(int pos)
        {
            if (pos >= 0)
            {
                int i = 0;
                Event p = head.Next;
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
                Event p = head.Next;
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
            Event p = head.Next;
            while (p != head)
            {
                listBox.Items.Add(p.NameEvent.ToString());
                listBox.Items.Add("Время события в часах:"+p.Time.ToString());
                p = p.Next;
            }
        }
    }
    class Event
    {
        private string nameEvent;
        private Event next;
        private Event prev;
        private int time;
        private Image picture;

        public int Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
            }
        }
        public Image Picture
        {
            get
            {
                return picture;
            }
            set
            {
                picture = value;
            }
        }
        public string NameEvent
        {
            get
            {
                return nameEvent;
            }
            set
            {
                nameEvent = value;
            }
        }
        public Event Next
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
        public Event Prev
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
        public Event()
        {
        }
        public Event(string info, int time, Image picture)
        {
            Picture = picture;
            NameEvent = info;
            Time = time; 
        }
        public Event(string nameEvent, Event next, Event prev, int time, Image picture)
        {
            Picture = picture;
            NameEvent = nameEvent;
            Next = next;
            Prev = prev;
            Time = time;
        }
    }
}
