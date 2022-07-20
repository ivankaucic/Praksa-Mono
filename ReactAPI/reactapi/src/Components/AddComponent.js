import React,{useState,useEffect} from 'react'

function AddComponent() {
    const [name, setName] = useState("");
    const [surname, setSurname] = useState("");
    const [age, setAge] = useState(null);
    const [turboDriver, setTurboDriver] = useState(false);
    const [price, setPrice] = useState(null);
    const [constructor, setConstructor] = useState(null);
    const [rules, setRules] = useState(null);
  return (
    <div>
        <form>
            <label>Input Name: </label>
            <input type="text"/><br/>
            <label>Input Surname: </label>
            <input type="text"/><br/>
            <label>Input Age: </label>
            <input type="number"/><br/>
            <label>Turbo Driver: </label>
            <input type="checkbox"/><br/>
            <label>Input Price: </label>
            <input type="number" step={0.5}/><br/>
            <label>Input Constructor(ID): </label>
            <input type="text"/><br/>
            <label>Input Scoring Rules(ID): </label>
            <input type="text"/><br/>
        </form>
        <button>Add driver</button>
    </div>
  )
}

export default AddComponent