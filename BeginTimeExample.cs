// // Copyright (c) Microsoft. All rights reserved.
// // Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Windows.Controls;
using System.Collections.Generic;

namespace AnimationTiming
{
    public partial class BeginTimeExample : Page
    {
        struct Time
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public float timeScale { get; set; }
        }

        interface IAggregate
        {
            IIterator CreateIterator();
        }

        interface IIterator
        {
            bool HasItem();

            Time NextItem();

            Time CurrentItem();

        }

        class TimeAggregate : IAggregate
        {
            List<Time> TimeList = new List<Time>();
            public void Add(Time time) => TimeList.Add(time);
            public Time GetItem(int index) => TimeList[index];
            public int count { get => TimeList.Count; }
            public IIterator CreateIterator() => new TimeIterator(this);
        }

        class TimeIterator : IIterator
        {
            TimeAggregate aggregate;
            int currentindex;
            public TimeIterator(TimeAggregate aggregate) => this.aggregate = aggregate;

            public Time CurrentItem() => aggregate.GetItem(currentindex);

            public bool HasItem()
            {
                if (currentindex < aggregate.count)
                    return true;
                return false;

            }

            public Time NextItem()
            {
                if (HasItem())
                    return aggregate.GetItem(currentindex++);
                return new Time();
            }

        }

        public void Main_function()
        {
            TimeAggregate aggregate = new TimeAggregate();

            aggregate.Add(new Time { ID = 1, Name = "Normal", timeScale = 1.5F });
            aggregate.Add(new Time { ID = 2, Name = "Normal-Medium", timeScale = 2.0F });
            aggregate.Add(new Time { ID = 3, Name = "Medium", timeScale = 3.5F });
            aggregate.Add(new Time { ID = 4, Name = "Medium-Long", timeScale = 4.5F });
            aggregate.Add(new Time { ID = 5, Name = "Long", timeScale = 5.5F });
            aggregate.Add(new Time { ID = 6, Name = "Long-ExLong", timeScale = 6.5F });

            IIterator iterator = aggregate.CreateIterator();

            while (iterator.HasItem())
            {
                System.Console.WriteLine($"ID: {iterator.CurrentItem().ID}\nName: " +
                    $"{iterator.CurrentItem().Name}\nTime Scale: " +
                    $"{iterator.CurrentItem().timeScale}\n");
                iterator.NextItem();
            }
            System.Console.ReadLine();
        }


    }
}