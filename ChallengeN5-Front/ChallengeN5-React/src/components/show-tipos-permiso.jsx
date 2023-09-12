import { Link } from 'react-router-dom';
import axios from '../axios.config.js'
import { useEffect, useState } from "react"

export function ShowTiposPermiso() {

    const [isLoading, setIsLoading] = useState(false);
    const [error, setError] = useState(null);
    const [tiposPermiso, setTiposPermiso] = useState(null);

    const getTiposPermiso = async () => {
        
        setIsLoading(true);

        await axios.get('/TipoPermisos/GetTiposPermisoAsync')
            .then((response) => {
                setTiposPermiso(response.data);
                setError(null);
            })
            .catch((error) => {

                setError(error.message);
                console.log(error.message);
            })
            .finally(() => {

                setIsLoading(false);
            });
    }

    const eliminarTipoPermiso = async (id) => {

        setIsLoading(true);

        await axios.delete(`/TipoPermisos/QuitarTipoPermisoAsync/${id}`)
        .then((response) => {
    
            setTiposPermiso(tiposPermiso.filter((tipoPermiso) => tipoPermiso.id !== id))
        })
        .catch((error) => {

            setError(error.message);
            console.log(error.message);
        })
        .finally(() => {

            setIsLoading(false);
        });
    };

    useEffect(() => {
        getTiposPermiso();
    }, [])

    const handleDelete = (id) => {
        if (window.confirm('¿Eliminar registro?')){

            eliminarTipoPermiso(id);
        }
    }

    return (
        <section>
            <table>
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Descripción</th>
                        <th>Acciones</th>
                    </tr>
                </thead>
                <tbody>

                    {tiposPermiso &&
                        tiposPermiso.map(({ id, descripcion }) => (
                            <tr key={id}>
                                <td>{id}</td>
                                <td>{descripcion}</td>
                                <td className='actions'>
                                    <Link to={`/tipos-permiso/${id}`} className='btn btn-editar'>🖋</Link>
                                    <button className='btn btn-eliminar' onClick={() => handleDelete(id)}>❌</button>
                                </td>
                            </tr>
                        ))}
                </tbody>

            </table>
        </section>
    )
}