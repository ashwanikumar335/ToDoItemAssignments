﻿using SmartIT.DebugHelper;
using System;
using ToDoItem.Data.Repositories;

namespace DatabaseTest
{
    class Program
    {
        static void Main(string[] args)
        {
            TodoItemRepository _todoRepository = new TodoItemRepository();
           // var todoList = _todoRepository.GetAll();
            //todoList.CDump("_todoRepository.GetAll()");
            //var findById = _todoRepository.FindById(2);
            //findById.CDump("_todoRepository.FindById(2)");
            //var newTodo = _todoRepository.Add(new Todo { Name = "Call a friend" });
            //_todoRepository.GetAll().CDump("Check if Call a friend todo added?");
            //newTodo.Name = newTodo.Name + " Updated";
            //_todoRepository.Update(newTodo);
            //_todoRepository.GetAll().CDump("Check if Call a friend todo updated with Updated?");
            //_todoRepository.Delete(_todoRepository.FindById(1));
            //_todoRepository.GetAll().CDump("Check if Id=1 todo is Deleted?");

            //Use below Employee repository to created CRUD operation
            //EmployeeRepository _employeeRepository = new EmployeeRepository();
            //_employeeRepository.Add(new Employee() { Name = "Ashwani Kumar", Gender = "Male", DepartmentId = 1, Salary = 10000 });
            //_employeeRepository.CDump("Employees");
            //{ "Items":[{"Id":1,"Name":"Mike","Gender":"Male","Salary":8000,"DepartmentId":1,"Department":null},
            //{"Id":2,"Name":"Adam","Gender":"Male","Salary":5000,"DepartmentId":1,"Department":null},
            //{"Id":3,"Name":"Jacky","Gender":"Female","Salary":9000,"DepartmentId":1,"Department":null},
            //{"Id":4,"Name":"Mat Stone","Gender":"Male","Salary":8000,"DepartmentId":2,"Department":null}],"Count":4}

            Console.ReadLine();

        }
    }
}
