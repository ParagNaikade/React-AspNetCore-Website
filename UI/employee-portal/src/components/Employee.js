const Employee = (props) => {
    const { Id, FirstName, LastName, Email, Gender, Status } = props.employee;

    return (
        <tr className={`${Status ? 'table-success' : 'table-secondary'}`}>
            <th scope="row">{Id}</th>
            <td>{FirstName}</td>
            <td>{LastName}</td>
            <td>{Email}</td>
            <td>{Gender}</td>
            <td>{String(Status)}</td>
        </tr>
    );
}

export default Employee;