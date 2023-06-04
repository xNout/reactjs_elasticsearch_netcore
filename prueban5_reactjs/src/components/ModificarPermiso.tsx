import * as React from 'react';
import { connect } from 'react-redux';
import { ApplicationState } from '../store';
import Layout from './Layout';
import { actionCreators } from '../store/permisos/creators'
import Swal from '../Common/Swal';
import { TipoPermisoDto } from '../Models/PermisoInfoDto';
import { ModificarPermisoDto } from '../Models/ModificarPermisoDto';


type props = ApplicationState & typeof actionCreators;

interface ModificarPermisoState {
    Id: string;
    Nombre: string;
    Apellido: string;
    TipoPermiso: string;
    FechaPermiso: Date;
}
class ModificarPermiso extends React.Component<props, ModificarPermisoState>
{
    constructor(props: any)
    {
        super(props);
        this.Modificar = this.Modificar.bind(this);
        this.HandleChange = this.HandleChange.bind(this);
        this.Validar = this.Validar.bind(this);
        this.state = {
            Id: "",
            Nombre: "",
            Apellido: "",
            TipoPermiso: "",
            FechaPermiso: new Date()
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
        this.props.loadTipoPermisos();
    }

    Modificar()
    {
        const { Id, Nombre, Apellido, TipoPermiso, FechaPermiso } = this.state;

        let Validaciones = this.Validar();
        if(Validaciones !== "")
        {
            Swal.Warn(Validaciones);
            return;
        }
        
        let Modelo: ModificarPermisoDto = {
            nombreEmpleado: Nombre,
            apellidoEmpleado: Apellido,
            tipoPermiso: Number(TipoPermiso),
            fechaPermiso: FechaPermiso
        };

        this.props.modificar(Number(Id), Modelo);
    }

    Validar()
    {
        const { Id, Nombre, Apellido, TipoPermiso, FechaPermiso } = this.state;
        if(!Id || Id === "")
        {
            return "El campo ID es obligatorio";
        }

        if(!Nombre || Nombre === "")
        {
            return "El campo Nombre es obligatorio";
        }

        if(!Apellido || Apellido === "")
        {
            return "El campo Apellido es obligatorio";
        }

        if(!TipoPermiso || TipoPermiso === "")
        {
            return "El campo Tipo Permiso es obligatorio";
        }

        if(!FechaPermiso)
        {
            return "El campo Fecha Permiso es obligatorio";
        }

        return "";
    }
    public render() {
        const { Id, Nombre, Apellido, TipoPermiso, FechaPermiso } = this.state;
        return <Layout>
            <div className="pure-u-1 modulo_obtpermisos">

                <div className="w-100"></div>
                <form className="pure-form pure-form-aligned">
                    <fieldset>
                        <legend>Modificar permiso</legend>
                    </fieldset>
                    <fieldset>
                        <div className="pure-control-group">
                            <label className="pure-u-3-24">Id</label>
                            <input type="number" name="Id" min={1} value={Id} onChange={this.HandleChange} placeholder="ID Permiso" />
                        </div>
                        <div className="pure-control-group">
                            <label className="pure-u-3-24">Nombres</label>
                            <input type="text" className="pure-u-12-24" maxLength={100} name="Nombre" value={Nombre} onChange={this.HandleChange} placeholder="Nombre" />
                        </div>
                        <div className="pure-control-group">
                            <label className="pure-u-3-24">Apellidos</label>
                            <input type="text" className="pure-u-12-24" name="Apellido" maxLength={100} value={Apellido} onChange={this.HandleChange} placeholder="Apellido" />
                        </div>
                        <div className="pure-control-group">
                            <label className="pure-u-3-24">Tipo Permiso</label>
                            <select name="TipoPermiso" defaultValue={TipoPermiso} onChange={this.HandleChange} className="pure-input-12-24">
                                {
                                    this.props.permisos.tipoPermisos.map((item: TipoPermisoDto) => 
                                    <option value={item.id} key={item.id}>{item.descripcion}</option>)
                                }
                                <option value="" disabled selected>Seleccionar...</option>
                            </select>
                        </div>

                        <div className="pure-control-group">
                            <label className="pure-u-3-24">Fecha Permiso</label>
                            <input type="date" className="pure-u-12-24" name="FechaPermiso" onChange={this.HandleChange} placeholder="Fecha Permiso" />
                        </div>

                        <button type="button" onClick={this.Modificar} className="pure-button pure-button-primary">Modificar</button>
                    </fieldset>
                </form>
            </div>
        </Layout>
    }
}

export default connect((state: ApplicationState) => ({
    permisos: state.permisos
  }), actionCreators)(ModificarPermiso as any)

