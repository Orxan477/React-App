import { Container, Row } from "reactstrap";
import Navbar from "./Components/Navbar/Navbar";
import "./assets/css/style.css";
import Intro from "./Components/Intro/Intro";
import Employee from "./Components/Employee/Employee";

function App() {
  async function getData(){
    let fetchData= await fetch('https://localhost:44392/api/employee');
    let data =await fetchData.json();
    console.log(data)
  }
  getData();
  
  return (
    <div>
      <Container>
        <Row>
          <Navbar />
        </Row>
      </Container>
      <section className="p-0 d-flex ">
        <Intro />
      </section>
      <section className="mt-5   card-sec">
        <Employee />
      </section>
    </div>
  );
}

export default App;
