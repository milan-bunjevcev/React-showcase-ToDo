type TableRowProps = {
  taskName: string;
  isCompleted: boolean;
  changeTaskStatus: () => void;
  deleteTask: () => void;
};

export const TableRow = (props: TableRowProps) => {
  const statusText = props.isCompleted ? "Done" : "Pending";
  const itemStatusClass = props.isCompleted
    ? "badge bg-success"
    : "badge bg-warning";

  return (
    <tr className="fw-normal">
      <td className="align-middle">
        <span>{props.taskName}</span>
      </td>
      <td className="align-middle">
        <h6 className="mb-0">
          <span className={itemStatusClass}>{statusText}</span>
        </h6>
      </td>
      <td className="align-middle">
        {props.isCompleted ? (
          <span data-mdb-toggle="tooltip" title="Undo">
            <img
              src="images/undo.png"
              alt="Delete"
              className="action-icon"
              onClick={props.changeTaskStatus}
            />
          </span>
        ) : (
          <span data-mdb-toggle="tooltip" title="Done">
            <img
              src="images/done.png"
              alt="Delete"
              className="action-icon"
              onClick={props.changeTaskStatus}
            />
          </span>
        )}

        <span data-mdb-toggle="tooltip" title="Remove">
          <img
            src="images/delete.png"
            alt="Delete"
            className="action-icon"
            onClick={props.deleteTask}
          />
        </span>
      </td>
    </tr>
  );
};
