import axios from 'axios';
import http from "./http-common";

const getDriver = id =>{
    return http.get(`/driver_By_Id_list?id=${id}`);
};

const createDriver = data =>{
    return http.post("/add_driver",data);
};

const updateDriver = (id,data) => {
    return http.put(`/update_driver?id=${id}`,data);
};

const deleteDriver = id =>{
    return http.delete(`/delete_driver?id=${id}`);
};

const findDriverByPrice = (higher) => {
    return http.get(`/driver_filter_list?totalPriceIsHigher=${higher}`);
};

const DriverService = {
    findDriverByPrice,
    getDriver,
    createDriver,
    updateDriver,
    deleteDriver
  };
  
  export default DriverService;