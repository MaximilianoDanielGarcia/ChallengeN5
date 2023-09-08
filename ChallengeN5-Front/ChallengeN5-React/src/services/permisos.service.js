import axios from '../axios.config.js'

const getPermisos = () => {
    axios.get('Permisos/GetPermisos')
}

const PermisosService = {
    getPermisos
}

export default { PermisosService };