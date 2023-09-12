import { Link } from "react-router-dom";
import { ShowPermisos } from "../components/show-permisos";
import { ShowTiposPermiso } from "../components/show-tipos-permiso";

export function Home() {

    return (
        <>
            <main className='container'>
                
                <div className='subtitle'>
                    <h2>Tipos de permisos</h2>
                    <Link to={"/tipos-permiso"} className='btn-add'><span>Agregar</span></Link>
                </div>
                <ShowTiposPermiso />

                <div className='subtitle'>
                    <h2>Permisos</h2>
                    <Link to={"/permisos"} className='btn-add'><span>Agregar</span></Link>
                </div>

                <ShowPermisos />
            </main>
        </>
    )
}