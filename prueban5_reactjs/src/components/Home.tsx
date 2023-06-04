import * as React from 'react';
import { connect } from 'react-redux';
import { ApplicationState } from '../store';
import Layout from './Layout';
import { actionCreators } from '../store/permisos/creators'


type props = ApplicationState & typeof actionCreators;

class Home extends React.Component<props>
{
    constructor(props: any)
    {
        super(props);
    }
    componentDidMount()
    {
        this.props.getAll();
    }

    public render() {
        const { listado } = this.props.permisos;
        return <Layout>
            <div className="pure-u-1 modulo_obtpermisos">

                <h5>Obtener permisos</h5>

                <div className="w-100"></div>
                <table className="pure-table pure-table-bordered tabla_permisos">
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Nombre</th>
                            <th>Apellido</th>
                            <th>Permiso</th>
                            <th>Fecha Asignacion</th>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            listado.length == 0 &&
                            <tr>
                                <td colSpan={5}>No se encontraron resultados</td>
                            </tr>  
                        }
                        {
                            listado.map(permiso => 
                                <tr key={permiso.id}>
                                    <td>{permiso.id}</td>
                                    <td>{permiso.nombreEmpleado}</td>
                                    <td>{permiso.apellidoEmpleado}</td>
                                    <td>{permiso.descripcionPermiso}</td>
                                    <td>{new Date(permiso.fechaPermiso).toLocaleString()}</td>
                                </tr>)
                        }
                        
                    </tbody>
                </table>
            </div>
        </Layout>
    }
}

export default connect((state: ApplicationState) => ({
    permisos: state.permisos
  }), actionCreators)(Home as any)

