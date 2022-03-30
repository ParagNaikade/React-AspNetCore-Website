import { useState } from 'react';
import Modal from 'react-bootstrap/Modal'
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button'

export const AddEmployeeModal = ({ onSubmit }) => {
  const [show, setShow] = useState(false);
  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  const [email, setEmail] = useState('');
  const [gender, setGender] = useState('Male');
  const [status, setStatus] = useState(true);

  const [validated, setValidated] = useState(false);

  const handleSubmit = (event) => {
    const form = event.currentTarget;
    if (form.checkValidity() === false) {
      event.preventDefault();
      event.stopPropagation();
    }

    setValidated(true);
    handleClose();

    onSubmit({
      firstName: firstName,
      lastName: lastName,
      email: email,
      gender: gender,
      status: status
    });
  };

  const firstNameChanged = (event) => {
    setFirstName(event.target.value);
  };

  const lastNameChanged = (event) => {
    setLastName(event.target.value);
  };

  const emailChanged = (event) => {
    setEmail(event.target.value);
  };

  const genderChanged = (event) => {
    setGender(event.target.value);
  };

  const statusChanged = (event) => {
    console.warn(event.target.checked);
    setStatus(event.target.checked);
  };

  return (
    <>
      <button className="btn btn-primary" onClick={handleShow}>
        Add New
      </button>

      <Modal show={show} onHide={handleClose}>
        <Form validated={validated} onSubmit={handleSubmit}>
          <Modal.Header closeButton>
            <Modal.Title>Add New Employee</Modal.Title>
          </Modal.Header>

          <Modal.Body>
            <Form.Group className="mb-3" controlId="formFirstName">
              <Form.Label>First Name</Form.Label>
              <Form.Control type="text" placeholder="Enter first name" required value={firstName} onChange={firstNameChanged} />
            </Form.Group>

            <Form.Group className="mb-3" controlId="formLastName">
              <Form.Label>Last Name</Form.Label>
              <Form.Control type="text" placeholder="Enter last name" required value={lastName} onChange={lastNameChanged} />
            </Form.Group>

            <Form.Group className="mb-3" controlId="formBasicEmail">
              <Form.Label>Email address</Form.Label>
              <Form.Control type="email" placeholder="Enter email" required value={email} onChange={emailChanged} />
            </Form.Group>

            <Form.Group className="mb-3" controlId="formGender">
              <Form.Label>Gender</Form.Label>
              <Form.Select onChange={genderChanged} defaultValue={gender}>
                <option value="Male">Male</option>
                <option value="Female">Female</option>
              </Form.Select>
            </Form.Group>

            <Form.Group className="mb-3" controlId="formStatus">
              <Form.Label>Status</Form.Label>
              <Form.Check
                label="Active"
                type="checkbox"
                id="checkbox-1"
                checked={status}
                onChange={statusChanged}
              />
            </Form.Group>
          </Modal.Body>

          <Modal.Footer>
            <Button variant="secondary" onClick={handleClose}>
              Close
            </Button>
            <Button variant="primary" type="submit">
              Add
            </Button>
          </Modal.Footer>
        </Form>
      </Modal>

    </>
  );
}
