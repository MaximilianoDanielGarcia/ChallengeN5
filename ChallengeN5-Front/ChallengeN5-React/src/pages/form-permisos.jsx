import { useEffect, useState } from "react";
import { Link, useNavigate, useParams } from "react-router-dom";
import axios from '../axios.config.js';

export function FormPermisos() {

    const INITIAL_VALUES = {
        "nombreEmpleado": "",
        "apellidoEmpleado": "",
        "tipoPermisoId": 0
    }

    const { id } = useParams();
    const [isEditMode, setEditMode] = useState(id != null);
    const [isLoading, setIsLoading] = useState(false);
    const [error, setError] = useState(null);
    const [permiso, setPermiso] = useState(INITIAL_VALUES);
    const [tiposPermiso, setTiposPermiso] = useState(null);
    const [errorForm, setErrorForm] = useState(INITIAL_VALUES);

    const navigate = useNavigate();

    const getPermisoById = async (id) => {

        setIsLoading(true);
        await axios.get(`/Permisos/GetPermisoByIdAsync/${id}`)
            .then(function (response) {

                setPermiso(response.data);
                setError(null);
            })
            .catch((error) => {

                setError(error.message);
                console.log(error.message);
            })
            .finally(() => {
                setIsLoading(false);
            });
    };

    const registrarPermiso = async (data) => {

        console.log(data);
        setIsLoading(true);
        await axios.post("/Permisos/RegistrarPermisoAsync", data)
            .then(function (response) {

                setError(null);
            })
            .catch((error) => {

                setError(error.message);
                console.log(error.message);
            })
            .finally(() => {

                setIsLoading(false);
            });
    };

    const modificarPermiso = async (data) => {

        setIsLoading(true);

        await axios.patch(`/Permisos/ModificarPermisoAsync/${id}`, data)
            .then(function (response) {

                return response;
            })
            .catch((error) => {

                setError(error.message);
                console.log(error.message);
            })
            .finally(() => {

                setIsLoading(false);
            });
    };

    const getTiposPermiso = async () => {

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

    useEffect(() => {

        getTiposPermiso();

        if (isEditMode) {
            getPermisoById(id);
        }

    }, [])

    const handleChange = (e) => {

        const { name, value } = e.target;

        setPermiso(prevState => ({
            ...prevState,
            [name]: value
        }));
    }

    const handleSubmit = (e) => {
        e.preventDefault();

        if (validateForm()) {

            if (isEditMode) {
                modificarPermiso(permiso);

            } else {
                registrarPermiso(permiso)
            }

            resetForm();

            if (window.confirm('Guardado exitosamente. ¿Desea volver a la pantalla inicial?')) {
                navigate('/', { replace: true });
            }
        }
    };

    const resetForm = () => {
        setPermiso(INITIAL_VALUES);
        setErrorForm(INITIAL_VALUES);
    }

    const validateForm = () => {

        let isValid = true;

        if (permiso.nombreEmpleado === '') {

            isValid = false;
            setErrorForm(prevState => ({
                ...prevState,
                ['nombreEmpleado']: 'El nombre es requerido.'
            }));
        }

        if (permiso.apellidoEmpleado === '') {

            isValid = false;
            setErrorForm(prevState => ({
                ...prevState,
                ['apellidoEmpleado']: 'El apellido es requerido.'
            }));
        }

        if (permiso.tipoPermisoId === 0) {

            isValid = false;
            setErrorForm(prevState => ({
                ...prevState,
                ['tipoPermisoId']: 'Debe elegir un permiso.'
            }));
        }

        return isValid;
    }

    return (
        <div className='form-container'>

            <form onSubmit={handleSubmit} className="form-permiso">
                {
                    isEditMode && permiso && (
                        <div className='form-group'>
                            <label htmlFor='permisoId'>Id</label>
                            <input type="text"
                                id='permisoId'
                                name='permisoId'
                                value={permiso.id}
                                readOnly
                            />
                        </div>
                    )
                }

                <div className='form-group'>
                    <label htmlFor='nombreEmpleado'>Nombre</label>
                    <input type="text"
                        id='nombreEmpleado'
                        name='nombreEmpleado'
                        onChange={handleChange}
                        defaultValue={permiso != null ? permiso.nombreEmpleado : ''}
                    />
                    {errorForm.nombreEmpleado.length > 0 && <p style={{color: 'red'}}>{errorForm.nombreEmpleado}</p>}
                </div>
                <div className='form-group'>
                    <label htmlFor='apellidoEmpleado'>Apellido</label>
                    <input type="text"
                        id='apellidoEmpleado'
                        name='apellidoEmpleado'
                        onChange={handleChange}
                        defaultValue={permiso != null ? permiso.apellidoEmpleado : ''}
                    />
                    {errorForm.apellidoEmpleado.length > 0 && <p style={{color: 'red'}}>{errorForm.apellidoEmpleado}</p>}
                </div>

                <div className='form-group'>
                    <label htmlFor='tipoPermisoId'>Tipo Permiso</label>
                    <select name="tipoPermisoId"
                        id="tipoPermisoId"
                        className="select"
                        onChange={handleChange}
                        value={permiso != null ? permiso.tipoPermisoId : '0'}>
                        <option value="0">Seleccione una opción</option>
                        {
                            tiposPermiso &&
                            tiposPermiso.map((tipoPermiso) => (
                                <option key={tipoPermiso.id} value={tipoPermiso.id}>{tipoPermiso.descripcion}</option>
                            ))
                        }
                    </select>
                    {errorForm.tipoPermisoId.length > 0 && <p style={{color: 'red'}}>{errorForm.tipoPermisoId}</p>}
                </div>

                {
                    isEditMode && permiso && (

                        <div className='form-group'>
                            <label htmlFor='fechaPermiso'>Fecha</label>
                            <input type="text"
                                id='fechaPermiso'
                                name='fechaPermiso'
                                value={permiso.fechaPermiso}
                                readOnly
                            />
                        </div>
                    )
                }
                <div className="form-actions">
                    <button type='submit' className='btn-submit'>
                        Guardar
                    </button>
                    <Link to={'/'} className="btn-back">
                        Volver
                    </Link>
                </div>

            </form>
        </div>
    )
}