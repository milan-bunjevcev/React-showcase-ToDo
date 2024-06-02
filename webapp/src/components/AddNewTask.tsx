import { useState } from "react";

export type AddNewTaskProps = {
  addNewTask: (newTaskName: string) => void;
};

export const AddNewTask = (props: AddNewTaskProps) => {
  const [newTaskName, setNewTaskName] = useState("");

  const addNewTaskOnClick = () => {
    props.addNewTask(newTaskName);
  };

  return (
    <div className="card-footer text-end p-3">
      <div className="row justify-content-start">
        <div className="col-6 col-sm-6 col-md-8 col-lg-10 col-xl-10 col-xxl-10">
          <div className="form-outline">
            <input
              type="text"
              id="new-item-input"
              className="form-control"
              value={newTaskName}
              onChange={(event) => setNewTaskName(event.target.value)}
            />
            <label className="form-label" htmlFor="new-item-input">
              What do you want to do?
            </label>
          </div>
        </div>
        <div className="col-6 col-sm-6 col-md-4 col-lg-2 col-xl-2 col-xxl-2">
          <button className="btn btn-add" onClick={addNewTaskOnClick}>
            Add Task
          </button>
        </div>
      </div>
    </div>
  );
};
