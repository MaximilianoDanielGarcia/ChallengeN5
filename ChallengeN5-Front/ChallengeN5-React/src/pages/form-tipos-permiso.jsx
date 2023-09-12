import { useEffect, useState } from "react";
import { Link, useNavigate, useParams } from "react-router-dom";
import axios from '../axios.config.js';

export function FormTiposPermiso() {

    const INITIAL_VALUES = {
        "descripcion": ""
    }

    const { id } = useParams();
    const [isEditMode, setEditMode] = useState(id != null);
    const [isLoading, setIsLoading] = useState(false);
    const [error, setError] = useState(null);
    const [tipoPermiso, setTipoPermiso] = useState(INITIAL_VALUES);
    const [errorForm, setErrorForm] = useState(INITIAL_VALUES);
    const navigate = useNavigate();

    const getTipoPermisoById = async (id) => {

        setIsLoading(true);
        await axios.get(`/TipoPermisos/GetTipoPermisoByIdAsync/${id}`)
            .then(function (response) {

                setTipoPermiso(response.data);
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

        setIsLoading(true);

        await axios.post("/TipoPermisos/RegistrarTipoPermisoAsync", data)
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

        await axios.patch(`/TipoPermisos/ModificarTipoPermisoAsync/${id}`, data)
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

    useEffect(() => {

        if (isEditMode) {
            getTipoPermisoById(id);
        }

    }, [])

    const handleChange = (e) => {
        const { name, value } = e.target;

        setTipoPermiso(prevState => ({
            ...prevState,
            [name]: value
        }));
    }

    const handleSubmit = (e) => {
        e.preventDefault();

        if (validateForm()) {

            if (isEditMode) {
                modificarPermiso(tipoPermiso);

            } else {
                registrarPermiso(tipoPermiso)
            }

            resetForm();

            if (window.confirm('Guardado exitosamente. ¿Desea volver a la pantalla inicial?')) {
                navigate('/', { replace: true });
            }
        }
    };

    const resetForm = () => {
        setTipoPermiso(INITIAL_VALUES);
        setErrorForm(INITIAL_VALUES);
    }

    const validateForm = () => {

        let isValid = true;

        if (tipoPermiso.descripcion === '') {

            isValid = false;
            setErrorForm(prevState => ({
                ...prevState,
                ['descripcion']: 'Este campo es requerido.'
            }));
        }

        return isValid;
    }

    return (
        <div className='form-container'>

            <form onSubmit={handleSubmit} className="form">
                {
                    isEditMode && tipoPermiso && (
                        <div className='form-group'>
                            <label htmlFor='tipoPermisoId'>Id</label>
                            <input type="text"
                                id='tipoPermisoId'
                                name='tipoPermisoId'
                                value={tipoPermiso.id}
                                readOnly
                            />
                        </div>
                    )
                }

                <div className='form-group'>
                    <label htmlFor='descripcion'>Descripción</label>
                    <input type="text"
                        id='descripcion'
                        name='descripcion'
                        onChange={handleChange}
                        defaultValue={tipoPermiso != null ? tipoPermiso.descripcion : ''}
                    />
                     {errorForm.descripcion.length > 0 && <p style={{color: 'red'}}>{errorForm.descripcion}</p>}
                </div>

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