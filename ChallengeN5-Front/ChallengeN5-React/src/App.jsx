import './App.css'
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'
import { Home } from './pages/home'
import { FormPermisos } from './pages/form-permisos'
import { FormTiposPermiso } from './pages/form-tipos-permiso'

function App() {

  return (
    <>
      <h1>Challenge N5-Now!</h1>
      <Router>
        <Routes>
          <Route exact path='/' element={<Home />} />
          <Route path='/permisos/:id?' element={<FormPermisos />} />
          <Route path='/tipos-permiso/:id?' element={<FormTiposPermiso />} />
        </Routes>
      </Router>
    </>
  )
}

export default App
