import * as React from 'react';
import { connect } from 'react-redux';
import { ApplicationState } from '../store';
import Layout from './Layout';
import { actionCreators } from '../store/permisos/creators'
import Swal from '../Common/Swal';
import { SolicitarPermisoModelDto } from '../Models/SolicitarPermisoModelDto';


type props = ApplicationState & typeof actionCreators;

class SolicitarPermiso extends React.Component<props, SolicitarPermisoModelDto>
{
    constructor(props: any)
    {
        super(props);
        this.Solicitar = this.Solicitar.bind(this);
        this.HandleChange = this.HandleChange.bind(this);
        this.state = {
            NombreEmpleado: "",
            ApellidoEmpleado: ""
        };
    }

    HandleChange(e: React.FormEvent<HTMLInputElement | HTMLSelectElement>) {
        const { name, value, className } = e.currentTarget;

        this.setState({
            ...this.state,
            [name]: value
        });
    }
    componentDidMount()
    {
        
    }

    Solicitar()
    {
        const { NombreEmpleado, ApellidoEmpleado } = this.state;

        if(!NombreEmpleado)
        {
            Swal.Error("Debes ingresar un nombre");
            return;
        }
        if(!ApellidoEmpleado)
        {
            Swal.Error("Debes ingresar un apellido");
            return;
        }

        this.props.get(this.state);
    }
    public render() {
        const { NombreEmpleado, ApellidoEmpleado } = this.state;

        const { solicitado } = this.props.permisos;
        
        return <Layout>
            <div className="pure-u-1 modulo_obtpermisos">

                <div className="w-100"></div>
                <form className="pure-form">
                    <fieldset>
                        <legend>Solictar permiso</legend>
                        <input type="text" name="NombreEmpleado" min={1} value={NombreEmpleado} onChange={this.HandleChange} placeholder="Nombre" />
                        <input type="text" name="ApellidoEmpleado" min={1} value={ApellidoEmpleado} onChange={this.HandleChange} placeholder="Apellido" />
                        <button type="button" onClick={this.Solicitar} className="pure-button pure-button-primary">Buscar</button>
                    </fieldset>
                </form>
                <form className="pure-form pure-form-aligned">
                    <fieldset>
                        <div className="pure-control-group">
                            <label className="pure-u-3-24">Nombres</label>
                            <span className="pure-u-12-24">{solicitado?.nombreEmpleado || ""}</span>
                        </div>
                        <div className="pure-control-group">
                            <label className="pure-u-3-24">Apellidos</label>
                            <span className="pure-u-12-24">{solicitado?.apellidoEmpleado || ""}</span>
                        </div>
                        <div className="pure-control-group">
                            <label className="pure-u-3-24">Tipo Permiso</label>
                            <span className="pure-u-12-24">{solicitado?.descripcionPermiso || ""}</span>
                        </div>
                        <div className="pure-control-group">
                            <label className="pure-u-3-24">Fecha Asignacion</label>
                            <span className="pure-u-12-24">{solicitado?.fechaPermiso ? 
                            new Date(solicitado?.fechaPermiso).toLocaleString() : ""}</span>
                        </div>
                    </fieldset>
                </form>
            </div>
        </Layout>
    }
}

export default connect((state: ApplicationState) => ({
    permisos: state.permisos
  }), actionCreators)(SolicitarPermiso as any)

