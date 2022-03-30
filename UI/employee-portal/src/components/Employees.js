import React, { Component } from 'react';
import axios from 'axios';
import ReactPaginate from 'react-paginate';
import Employee from './Employee';
import { AddEmployeeModal } from './AddEmployeeModal';

export class Employees extends Component {

    constructor(props) {
        super(props);

        this.state = {
            data: [],
            currentPage: 0,
        };
    }

    loadEmployeesFromServer() {
        axios.get(`https://localhost:5001/api/employees?pageNumber=${this.state.currentPage + 1}&limit=10`)
            .then((response) => {
                this.setState({
                    data: response.data.Employees,
                    pageCount: response.data.TotalCount / 10,
                });
            })
            .catch((error) => {
                console.error(error);
            })
    }

    componentDidMount() {
        this.loadEmployeesFromServer();
    }

    handlePageClick = (data) => {
        console.log('onPageChange', data);

        this.setState({ currentPage: data.selected }, () => {
            this.loadEmployeesFromServer();
        });
    };

    addNewEmployeeInMemory = ({firstName, lastName, email, gender, status}) => {
        alert(`New employee details - First Name - ${firstName}, Last Name - ${lastName}, Email - ${email}, Gender - ${gender}, Status - ${status}`)
    }

    render() {
        return (
            <div className="container">
                <div className="card text-center">
                    <div className="card-header">
                        <h5>View Employees</h5>
                    </div>
                    <div className="card-body">
                        <div className="row form-control-lg col-2">
                            <AddEmployeeModal onSubmit={this.addNewEmployeeInMemory}></AddEmployeeModal>
                        </div>
                        <div className="row">
                            <div className="table-responsive">
                                <table className="table table-hover">
                                    <thead>
                                        <tr>
                                            <th scope="col">#</th>
                                            <th scope="col">First Name</th>
                                            <th scope="col">Last Name</th>
                                            <th scope="col">Email</th>
                                            <th scope="col">Gender</th>
                                            <th scope="col">Status</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        {this.state.data.map(employee =>
                                            <Employee key={employee.Id} employee={employee}></Employee>
                                        )}

                                    </tbody>
                                </table>
                            </div>
                        </div>

                        <div className="row">
                            <nav aria-label="Page navigation comments" className="mt-4">
                                <ReactPaginate
                                    previousLabel="previous"
                                    nextLabel="next"
                                    breakLabel="..."
                                    breakClassName="page-item"
                                    breakLinkClassName="page-link"
                                    pageCount={this.state.pageCount}
                                    pageRangeDisplayed={4}
                                    marginPagesDisplayed={2}
                                    onPageChange={this.handlePageClick}
                                    containerClassName="pagination justify-content-center"
                                    pageClassName="page-item"
                                    pageLinkClassName="page-link"
                                    previousClassName="page-item"
                                    previousLinkClassName="page-link"
                                    nextClassName="page-item"
                                    nextLinkClassName="page-link"
                                    activeClassName="active"
                                    // eslint-disable-next-line no-unused-vars
                                    hrefBuilder={(page, pageCount, selected) =>
                                        page >= 1 && page <= pageCount ? `/page/${page}` : '#'
                                    }
                                    hrefAllControls
                                    forcePage={this.state.currentPage}
                                    onClick={(clickEvent) => {
                                        console.log('onClick', clickEvent);
                                        // Return false to prevent standard page change,
                                        // return false; // --> Will do nothing.
                                        // return a number to choose the next page,
                                        // return 4; --> Will go to page 5 (index 4)
                                        // return nothing (undefined) to let standard behavior take place.
                                    }}
                                />
                            </nav>
                        </div>

                    </div>
                </div>
            </div>
        );
    }
}