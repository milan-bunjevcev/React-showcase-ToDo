import { CreateToDoTask } from "../types/CreateToDoTask";
import { EditToDoTask } from "../types/EditToDoTask";
import { ToDoTask } from "../types/ToDoTask";

const URL: string = "http://localhost:5111/api/tasks";
const getDefaultHeaders = (): Record<string, string> => ({
  "Content-Type": "application/json",
  Authorization: `Bearer ${localStorage.getItem("accessToken")}`,
});

export const getAllTasks = async (): Promise<ToDoTask[]> => {
  return await fetch(URL, {
    headers: getDefaultHeaders(),
    method: "GET",
  })
    .then((response) => response.json())
    .catch((errorMessage) => console.error(errorMessage));
};

export const editTask = async (
  id: string,
  task: EditToDoTask
): Promise<ToDoTask> => {
  return await fetch(`${URL}/${id}`, {
    headers: getDefaultHeaders(),
    method: "PUT",
    body: JSON.stringify(task),
  })
    .then((response) => response.json())
    .catch((errorMessage) => console.error(errorMessage));
};

export const addNewTask = async (
  newTask: CreateToDoTask
): Promise<ToDoTask> => {
  return await fetch(URL, {
    headers: getDefaultHeaders(),
    method: "POST",
    body: JSON.stringify(newTask),
  })
    .then((response) => response.json())
    .catch((errorMessage) => console.error(errorMessage));
};

export const deleteTask = async (taskId: string): Promise<void> => {
  await fetch(`${URL}/${taskId}`, {
    headers: getDefaultHeaders(),
    method: "DELETE",
  }).catch((errorMessage) => console.error(errorMessage));
};
