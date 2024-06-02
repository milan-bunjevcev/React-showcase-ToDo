import { useState, useEffect } from "react";
import { AddNewTask } from "../components/AddNewTask";
import { Header } from "../components/Header";
import { TableRow } from "../components/TableRow";
import {
  getAllTasks,
  addNewTask,
  editTask,
  deleteTask,
} from "../services/toDoService";
import { ToDoTask } from "../types/ToDoTask";

export const ToDoPage = () => {
  const [listOfTasks, setListOfTasks] = useState<ToDoTask[]>([]);

  const getAllTasksFromBackend = () => {
    getAllTasks().then((tasksFromBackedn) => {
      setListOfTasks(tasksFromBackedn);
    });
  };

  useEffect(() => {
    getAllTasksFromBackend();
  }, []);

  const addNewTaskAndRefresh = (newTaskName: string) => {
    addNewTask({ name: newTaskName }).then(() => {
      getAllTasksFromBackend();
    });
  };

  const rowsToShow = listOfTasks.map((task) => (
    <TableRow
      key={task.id}
      taskName={task.name}
      isCompleted={task.isCompleted}
      changeTaskStatus={() => {
        editTask(task.id, {
          name: task.name,
          isCompleted: !task.isCompleted,
        }).then(() => getAllTasksFromBackend());
      }}
      deleteTask={() => {
        deleteTask(task.id).then(() => getAllTasksFromBackend());
      }}
    />
  ));

  return (
    <div className="container py-5 h-100">
      <div className="row d-flex justify-content-center align-items-center h-100">
        <div className="col-md-12 col-xl-10">
          <div className="card card-gradient">
            <div className="card-body p-4">
              <Header />
              <table className="table mb-0">
                <thead>
                  <tr>
                    <th scope="col">Task</th>
                    <th scope="col">Status</th>
                    <th scope="col">Actions</th>
                  </tr>
                </thead>
                <tbody>{rowsToShow}</tbody>
              </table>
            </div>
            <AddNewTask addNewTask={addNewTaskAndRefresh} />
          </div>
        </div>
      </div>
    </div>
  );
};
