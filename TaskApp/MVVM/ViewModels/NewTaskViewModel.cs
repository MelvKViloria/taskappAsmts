using System.Collections.ObjectModel;
using TaskApp.MVVM.Models;
using PropertyChanged;
using System;

public class NewTaskViewModel
{
    public event EventHandler<TaskAddedEventArgs> TaskAdded;

    public string Task { get; set; }
    public ObservableCollection<MyTask> Tasks { get; set; }
    public ObservableCollection<Category> Categories { get; set; }
    public Category SelectedCategory { get; set; }

    public NewTaskViewModel()
        //here is the colors for the category tasks
    {
        Categories = new ObservableCollection<Category>()
        {
            new Category
            {
                Id = 1,
<<<<<<< Updated upstream
                CategoryName = "Inventory Management",
                Color = "#84B94A"
=======
                CategoryName = "check inventory",
                Color = "#ff0000"
>>>>>>> Stashed changes
            },
            new Category
            {
                Id = 2,
<<<<<<< Updated upstream
                CategoryName = "Order Processing",
                Color = "#E09735"
=======
                CategoryName = "manage orders",
                Color = "#007BFF"
>>>>>>> Stashed changes
            },
            new Category
            {
                Id = 3,
<<<<<<< Updated upstream
                CategoryName = "Scheduling",
                Color = "#D935E0"
            },
            new Category
            {
                Id= 4,
                CategoryName = "Customer Interactions",
                Color = "Pink"
=======
                CategoryName = "scheduling",
                Color = "#008000"
>>>>>>> Stashed changes
            }
        };

        //here i am adding the default tasks to the page
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
                CategoryId = 2,
            },
=======
                TName = "send food stock orders",
                Done = false,
                CategoryId = 2,
            },
            new MyTask
            {
                TName = "start baking items",
                Done = false,
                CategoryId = 3,
            },
            new MyTask
            {
                TName = "display baked goods",
                Done = false,
                CategoryId = 3,
            },
             new MyTask
            {
                TName = "schedule future orders",
                Done = false,
                CategoryId = 3,
            }
        };
    }
>>>>>>> Stashed changes

            new MyTask
            {
                TaskName = "Look through day",
                Completed = false,
                CategoryId = 3,
            },
            new MyTask
            {
                TaskName = "Deligate Jobs to staff",
                Completed = false,
                CategoryId = 3,
            },
            new MyTask
            {
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
            };
    }
    //here i have the new task add function
    public class TaskAddedEventArgs : EventArgs
    {
        public MyTask NewTask { get; }

        public TaskAddedEventArgs(MyTask newTask)
        {
            NewTask = newTask;
        }
    }

    //here i am carrying on with the add task function
   public void AddTask()
    {
        if (SelectedCategory != null)
        {
            var newTask = new MyTask { TName = Task, Done = false, CategoryId = SelectedCategory.Id };
            SelectedCategory.AddTask(newTask);
            TaskAdded?.Invoke(this, new TaskAddedEventArgs(newTask));
            Task = string.Empty;
        }
    }
}
