import Swal from 'sweetalert2';


export default class SwalAlerts {

    public static Cerrar() {
        Swal.close();
    }

    public static Error(text: string, title: string = "Ocurrió un error") {
        Swal.fire({
            icon: 'error',
            title: title,
            text: text,
            heightAuto: false
        })
    }
    public static Carga(text: string, title: string = "Espere por favor") {
        Swal.fire({
            icon: 'info',
            title: title,
            text: text,
            showConfirmButton: false,
            timer: 30 * 1000,
            heightAuto: false
        })
    }
    public static Warn(text: string, title: string = "Advertencia") {
        Swal.fire({
            icon: 'warning',
            title: title,
            text: text,
            heightAuto: false
        })
    }
    public static Info(text: string, title: string = "Información") {
        Swal.fire({
            icon: 'info',
            title: title,
            text: text,
            heightAuto: false
        })
    }
    public static Exito(text: string, title: string = "Información") {
        Swal.fire({
            icon: 'success',
            title: title,
            text: text,
            heightAuto: false
        })
    }
}