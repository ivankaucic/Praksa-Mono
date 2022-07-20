import React from 'react';
import './Table.css';

function Table(props) {
  return (
    <table className="myTable" id="myTable">
      <tbody>
            <tr id="tableHeader">
                <td className="tableHeaderElement" id="driverHeader">{props.driverId}</td>
                <td className="tableHeaderElement" id="driverHeader">{props.driverName}</td>
                <td className="tableHeaderElement" id="driverHeader">{props.driverSurname}</td>
                <td className="tableHeaderElement" id="driverHeader">{props.driverPrice}</td>
                <td className="tableHeaderElement" id="driverHeader"></td>
            </tr>
            {props.drivers.map((driver) => (
                <tr key={driver.DriverId}>
                  <td>{driver.DriverId}</td>
                  <td>{driver.DriverName}</td>
                  <td>{driver.DriverSurname}</td>
                  <td>{driver.Price}</td>
                  <td>
                    <button>Edit</button>
                    <button>Delete</button>
                  </td>
                </tr>
            ))}
      </tbody>
    </table>
  )
}

export default Table;