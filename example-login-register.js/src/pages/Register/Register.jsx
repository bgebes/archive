import React from 'react';
import RegisterImage from '../../assets/images/imgRegister.jpg';
import ButtonList from '../../components/ButtonList/ButtonList';
import RegisterForm from '../../components/RegisterForm/RegisterForm';

function Register({ usersState }) {
  const [users, setUsers] = usersState;

  return (
    <div className="row w-75 border-secondary border rounded shadow-lg">
      <div className="col-6 p-0">
        <img
          className="w-100 rounded-start border-end"
          src={RegisterImage}
          alt="Home Image"
        />
      </div>
      <div className="col-6 p-0 rounded-end bg-white">
        <div className="d-flex flex-column justify-content-center h-100">
          <div className="mb-auto">
            <ButtonList />
          </div>
          <div className="text-success text-center fs-4 fw-semibold mb-5">
            Kayıt Ol
          </div>
          <RegisterForm usersState={[users, setUsers]} />
        </div>
      </div>
    </div>
  );
}

export default Register;
