import './App.css';
import Button from './Button.js';
import Form from './Form.js';
import Table from './Table.js';
import Scripts from './Scripts.js';
import Navbar from './NavBar.js';
import Image from './Image.js';

function App() {
  return (
    <div className="flex-container">
      <Navbar navItemNameOne="Home" navItemNameTwo="Info" navItemNameThree="Books" navItemNameFour="Authors"/>      
      <Form firstLabel="Enter book ID: " secondLabel="Enter book name: " thirdLabel="Enter book author: " 
            fourthLabel="Enter book price: "/>
      <Button message="Add a book"/>
      <Table bookId="Book ID" bookName="Book name" bookAuthor="Book author" bookPrice="Book price"/>
      <Scripts scriptName="addBooks.js"/>
      <Image source="../public/logo512.png"/>
    </div>    
  );
}

export default App;
