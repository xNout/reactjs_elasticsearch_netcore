import * as React from 'react';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import $ from 'jquery';
import 'purecss/build/pure-min.css';
import 'purecss/build/base-min.css';
import 'purecss/build/grids-min.css';
import 'purecss/build/grids-responsive-min.css';
import 'bootstrap/dist/css/bootstrap.css';

import '../css/layout.css';
import '../css/container.css';
import '../css/permisoslist.css';

class Layout extends React.Component<{ children?: React.ReactNode }>
{
    
    componentDidMount() {
        $("#sbmenu_btn").click(function () {

            const { innerWidth: width, innerHeight: height } = window;

            if (width > 568)
                ToggleMenu();

            else {
                if ($("#submenu").hasClass("submenu_small"))
                    ToggleMenu();


                $("#submenu").animate({ width: 'toggle' }, 350);
            }

            

        });

        function ToggleMenu() {
            $("#submenu").toggleClass("submenu_small");
            $("#submenu").toggleClass("pure-u-sm-1-4 pure-u-md-1-4 pure-u-lg-1-6");
            $("#submenu").toggleClass("pure-u-sm-2-24 pure-u-md-2-24 pure-u-lg-1-24");
            $("#bdysbncontent").toggleClass("pure-u-sm-21-24 pure-u-md-22-24 pure-u-lg-23-24");
            $("#bdysbncontent").toggleClass("pure-u-sm-22-24 pure-u-md-18-24 pure-u-lg-20-24");


            $(".icono_sbmenu").toggleClass("pure-u-3-24");
            $(".icono_sbmenu").toggleClass("pure-u-1");
            $(".subitems_menu").hide();
        }

        $(".item_sb").click(function () {
            $(this).children(".subitems_menu").slideToggle();
        });


        $(window).resize(function () {
            CheckSubMenu();
        });

        function CheckSubMenu() {
            const { innerWidth: width, innerHeight: height } = window;
            if (width <= 568) {
                if ($("#submenu").is(":visible"))
                    $("#submenu").hide();


            }
            else {
                if (!$("#submenu").is(":visible"))
                    $("#submenu").show();
            }
        }

        CheckSubMenu();
    }



    render() {

        return <>
            <div className="nav pure-u-1" style={{marginTop: "40px"}}>

                <div className="pure-u-4-24 pure-u-sm-2-24 pure-u-md-2-24 pure-u-lg-1-24 submenu">
                    <i className="fas fa-bars" id="sbmenu_btn"></i>
                </div>

                <div className="pure-u-10-24 pure-u-sm-5-24 pure-u-md-5-24 pure-u-lg-3-24 user_options">

                </div>
            </div>

            <div className="main pure-u-1">

                <div className="submenu pure-u-5-12 pure-u-sm-1-4 pure-u-md-1-4 pure-u-lg-1-6" id="submenu" style={{ display: "none"}}>

                    <div className="items pure-u-24-24">

                        <Link className="item pure-u-1" to="/solicitar">
                            <div className="icono_sbmenu pure-u-3-24">
                                <i className="fas fa-search"></i>
                            </div>
                            <div className="descp pure-u-16-24">
                                Solicitar Permiso
                            </div>
                        </Link>

                        <Link className="item pure-u-1" to="/modificar">
                            <div className="icono_sbmenu pure-u-3-24">
                                <i className="fas fa-pen"></i>
                            </div>
                            <div className="descp pure-u-16-24">
                                Modificar Permiso
                            </div>
                        </Link>

                        <Link className="item pure-u-1" to="/">
                            <div className="icono_sbmenu pure-u-3-24">
                                <i className="fas fa-user-tag"></i>
                            </div>
                            <div className="descp pure-u-16-24">
                                Obtener Permisos
                            </div>
                        </Link>

                    </div>
                </div>

                <div className="bodycontent pure-u-1 pure-u-sm-18-24 pure-u-md-18-24 pure-u-lg-20-24" id="bdysbncontent">
                    <div className="container">
                        {this.props.children}
                    </div>

                </div>
            </div>
        </>
    }
}

export default Layout;
