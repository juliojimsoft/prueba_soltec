import React from 'react'
import { Link } from 'react-router-dom';

const HomePage = () => {
  return (
    <div className="min-h-screen bg-gray-50 flex flex-col items-center justify-center">
      <h1 className="text-4xl font-bold text-blue-600 mb-8">Bienvenido a nuestra App</h1>
      <div className="flex space-x-4">
        <Link 
          to="/login" 
          className="px-6 py-3 bg-blue-500 text-white rounded-lg hover:bg-blue-600 transition"
        >
          Iniciar Sesión
        </Link>
        <Link 
          to="/register" 
          className="px-6 py-3 bg-gray-200 text-gray-800 rounded-lg hover:bg-gray-300 transition"
        >
          Registrarse
        </Link>
      </div>
    </div>
  );
}

export default HomePage