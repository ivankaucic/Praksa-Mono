import React,{useState,useEffect} from 'react'
import DriverApi from '../Services/DriverServices.js';
import Table from './Table.js';
import './GetAllComponent.css';

function GetAllComponent() {

    const [drivers, setDrivers] = useState([]);
    const [searchPrice, setSearchPrice] = useState(20);

    useEffect(() => {
        fetchDrivers();
    },[]);

    const onChangeSearchPrice = e => {
        const searchPrice = e.target.value;
        setSearchPrice(searchPrice);
        console.log(searchPrice);
      };

    const searchByValue = () => {
        fetchDrivers();
    };


    const fetchDrivers = () => {
        DriverApi.findDriverByPrice(searchPrice).then(response => {
            console.log(searchPrice);
            setDrivers(response.data);
            console.log(response.data);
        })
        .catch(e =>{
            console.log(e);
        });
    }; 

  return (
    <div id="gac">
        <Table driverId="#" driverName="Name" driverSurname="Surname" driverPrice="Price" drivers={drivers}/>
        <input min="0" max="50" type="number" id="submitNumber" name="submitNumber" value={searchPrice} onChange={onChangeSearchPrice}/>
        <button onClick={fetchDrivers}>Search</button>        
    </div>
  )
}

export default GetAllComponent