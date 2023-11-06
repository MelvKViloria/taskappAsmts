using System.Collections.ObjectModel;
using System.Collections.Specialized;
using TaskApp.MVVM.Models;
using PropertyChanged;
using System.Linq;

namespace TaskApp.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MainViewModel
    {
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<MyTask> Tasks { get; set; }

        public MainViewModel()
        {
            FileData();
            Tasks.CollectionChanged += Tasks_CollectionChanged;

            // Initialize the Tasks collection within each Category
            foreach (var category in Categories)
            {
                category.Tasks = new ObservableCollection<MyTask>(Tasks.Where(task => task.CategoryId == category.Id));
                category.UpdateTotalTasks();
            }
        }

        private void Tasks_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Handle tasks collection changes
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (MyTask task in e.NewItems)
                {
                    Category category = Categories.FirstOrDefault(c => c.Id == task.CategoryId);
                    if (category != null)
                    {
                        category.Tasks.Add(task);
                        category.PendingTasks = category.Tasks.Count(t => !t.Done);
                        category.Percentage = (float)category.Tasks.Count(t => t.Done) / category.Tasks.Count;
                        category.UpdateTotalTasks();
                    }
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (MyTask task in e.OldItems)
                {
                    Category category = Categories.FirstOrDefault(c => c.Id == task.CategoryId);
                    if (category != null)
                    {
                        category.Tasks.Remove(task);
                        category.PendingTasks = category.Tasks.Count(t => !t.Done);
                        category.Percentage = (float)category.Tasks.Count(t => t.Done) / category.Tasks.Count;
                        category.UpdateTotalTasks();
                    }
                }
            }
        }

        //here is the colors for the category names
        private void FileData()
        {
            Categories = new ObservableCollection<Category>()
            {
                new Category
<<<<<<< Updated upstream
            {
                Id = 1,
                CategoryName = "Inventory Management",
                Color = "#84B94A"
            },
            new Category
            {
                Id = 2,
                CategoryName = "Order Processing",
                Color = "#E09735"
            },
            new Category
            {
                Id = 3,
                CategoryName = "Scheduling",
                Color = "#D935E0"
            },
            new Category
            {
                Id= 4,
                CategoryName = "Customer Interactions",
                Color = "#FF5733"
            }
=======
                {
                    Id = 1,
                    CategoryName = "check inventory",
                    Color = "#ff0000"
                },

                new Category
                {
                    Id = 2,
                    CategoryName = "manage orders",
                    Color = "#009000"
                },

                new Category
                {
                    Id = 3,
                    CategoryName = "scheduling",
                    Color = "#007BFF"
                },
>>>>>>> Stashed changes
            };

            Tasks = new ObservableCollection<MyTask>()
            {
                  new MyTask
            {
<<<<<<< Updated upstream
                TaskName = "Look over storage for products getting low",
                Completed = false,
=======
                TName = "look at stock amount",
                Done = false,
>>>>>>> Stashed changes
                CategoryId = 1,
            },
            new MyTask
            {
<<<<<<< Updated upstream
                TaskName = "Add products to the grocery list if needed",
                Completed = false,
=======
                TName = "list what to buy",
                Done = false,
>>>>>>> Stashed changes
                CategoryId = 1,
            },
            new MyTask
            {
<<<<<<< Updated upstream
                TaskName = "Sort through orders",
                Completed = false,
=======
                TName = "start ordring items",
                Done = false,
>>>>>>> Stashed changes
                CategoryId = 2,
            },
            new MyTask
            {
<<<<<<< Updated upstream
                TaskName = "Pack orders",
                Completed = false,
=======
                TName = "send food stock orders",
                Done = false,
>>>>>>> Stashed changes
                CategoryId = 2,
            },

            new MyTask
            {
<<<<<<< Updated upstream
                TaskName = "Look through day",
                Completed = false,
=======
                TName = "start baking items",
                Done = false,
>>>>>>> Stashed changes
                CategoryId = 3,
            },
            new MyTask
            {
<<<<<<< Updated upstream
                TaskName = "Deligate Jobs to staff",
                Completed = false,
=======
                TName = "display baked goods",
                Done = false,
>>>>>>> Stashed changes
                CategoryId = 3,
            },
            new MyTask
            {
<<<<<<< Updated upstream
                TaskName = "Check Google Reviews and answer new reviews",
                Completed = false,
                CategoryId = 4,
            },
            new MyTask
            {
                TaskName = "Check Emails and Respond to emails",
                Completed = false,
                CategoryId = 4,
            }
=======
                TName = "schedule future orders",
                Done = false,
                CategoryId = 3,
            },
>>>>>>> Stashed changes
            };
            UpdateData();
        }

        //here the data is updating for the categories with completed and uncompleted tasks
        public void UpdateData()
        {
            foreach (var c in Categories)
            {
                var tasks = from t in Tasks
                            where t.CategoryId == c.Id
                            select t;

                var completed = from t in tasks
                                where t.Done == true
                                select t;

<<<<<<< Updated upstream
                var unCompleted = from t in tasks
                                  where t.Completed == false
=======
                var noCompleted = from t in tasks
                                  where t.Done == false
>>>>>>> Stashed changes
                                  select t;

                c.PendingTasks = unCompleted.Count();
                c.Percentage = (float)completed.Count() / (float)tasks.Count();
            }

            //This is the progress bar and when a task is completed the task bar increases
            foreach (var t in Tasks)
            {
                var catColor =
                    (
                        from c in Categories
                        where c.Id == t.CategoryId
                        select c.Color
                    ).FirstOrDefault();
                t.TColor = catColor;
            }
        }
    }
}