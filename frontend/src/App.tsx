import './App.css'
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'
import HomePage from './routes/HomePage'
import ProfilePage from './routes/ProfilePage'
import LoginPage from './routes/LoginPage'

function App() {
  return (
    <Router>
      <Routes>
        <Route path='/' Component={HomePage} />
        <Route path='/me' Component={ProfilePage} />
        <Route path='/login' Component={LoginPage} />
      </Routes>
    </Router>
  )
}

export default App
