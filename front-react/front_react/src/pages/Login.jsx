import React, { useState } from 'react'

const Login = () => {

  const [nombre, setNombre] = useState('');
  const [primerApellido, setPrimerApellido] = useState('');
  const [segundoApellido, setSegundoApellido] = useState('');
  const [password, setPassword] = useState('');
  

  return (
    <div>Login</div>
  )
}

export default Login