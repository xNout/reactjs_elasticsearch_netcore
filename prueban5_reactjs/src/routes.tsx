import * as React from 'react';
import { Route, Routes } from 'react-router';
import Home from './components/Home';
import SolicitarPermiso from './components/SolicitarPermiso';
import ModificarPermiso from './components/ModificarPermiso';
import './css/normalize.css';

export default function Rutas()
{
    return (
        <Routes>
            <Route path='/' element={<Home />} />
            <Route path='/solicitar' element={<SolicitarPermiso />} />
            <Route path='/modificar' element={<ModificarPermiso />} />
        </Routes>
    )
}
