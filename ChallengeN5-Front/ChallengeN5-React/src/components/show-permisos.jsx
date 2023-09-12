import { Link } from 'react-router-dom';
import axios from '../axios.config.js'
import { useEffect, useState } from "react"

export function ShowPermisos() {

    const [isLoading, setIsLoading] = useState(false);
    const [error, setError] = useState(null);
    const [permisos, setPermisos] = useState(null);
    const [tiposPermiso, setTiposPermiso] = useState(null);

    const getPermisos = async () => {
        
        setIsLoading(true);

        
        await axios.get('/Permisos/GetPermisosAsync')
            .then((response) => {
                
                setPermisos(response.data);
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

    const getTiposPermiso = async () => {
        
        setIsLoading(true);

        await axios.get(`/TipoPermisos/GetTiposPermisoAsync`)
            .then((response) => {

                setTiposPermiso(response.data);
            })
            .catch((error) => {

                console.log(error.message);
            })
    }

    const eliminarPermiso = async (id) => {

        setIsLoading(true);

        await axios.delete(`/Permisos/QuitarPermisoAsync/${id}`)
        .then((response) => {
    
            setPermisos(permisos.filter((permiso) => permiso.id !== id))
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
        getPermisos();
        getTiposPermiso();
    }, [])

    const handleDelete = (id) => {
        if (window.confirm('¿Eliminar registro?')){

            eliminarPermiso(id);
        }
    }

    const tipoPermisoDesc = (idTipo) => {

        return tiposPermiso != null ? tiposPermiso.find((tipo) => tipo.id == idTipo).descripcion : '';
    }

    return (
        <section>
            <table>
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Nombre</th>
                        <th>Apellido</th>
                        <th>Permiso</th>
                        <th>Fecha</th>
                        <th>Acciones</th>
                    </tr>
                </thead>
                <tbody>

                    {permisos &&
                        permisos.map(({ id, nombreEmpleado, apellidoEmpleado, fechaPermiso, tipoPermisoId }) => (
                            <tr key={id}>
                                <td>{id}</td>
                                <td>{nombreEmpleado}</td>
                                <td>{apellidoEmpleado}</td>
                                <td>{tipoPermisoDesc(tipoPermisoId)}</td>
                                <td>{fechaPermiso}</td>
                                <td className='actions'>
                                    <Link to={`/permisos/${id}`} className='btn btn-editar'>🖋</Link>
                                    <button className='btn btn-eliminar' onClick={() => handleDelete(id)}>❌</button>
                                </td>
                            </tr>
                        ))}
                </tbody>

            </table>
        </section>
    )
}