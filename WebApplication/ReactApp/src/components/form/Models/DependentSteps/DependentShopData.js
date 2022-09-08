import React, { useEffect, useState } from "react";
import FormText from '../../form-groups/FormText'
import FormSelect from '../../form-groups/FormSelect'
import FormMap from "../../form-groups/FormMap";



export default function DependentShopData(props) {

    const [options, setOptions] = useState(props.options)
    
    function transformarCoordenada(){
        if (props.props.latitude === undefined || props.props.latitude === null || props.props.longitude === undefined || props.props.longitude === null){
            return undefined;
        }
        const respuesta = {lat: props.props.latitude, 
            lng: props.props.longitude}
        return [respuesta];

       
    }
    return (
        <div >
            <FormText campo="address" label="Dirección del comercio" />
            <div className="grid md:grid-cols-2 md:gap-6">
                <FormText campo="nameShopData" label="Nombre del Comercio" />
                <FormSelect options={options} campo="neighborhood" label="Barrio" />
                <FormText campo="shopType" label="Tipo de Comercio" />
                <FormText campo="phoneShopData" label="Telefono de comercio" />
            </div>
            <br />
            <div className="grid md:grid-cols-1 md:gap-6">
                <FormMap  coordenadas = {transformarCoordenada()} campoLat="latitude" campoLng="longitude" />
            </div>

        </div>
    )
}