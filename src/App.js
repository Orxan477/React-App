import { Container, Row } from "reactstrap";
import Navbar from "./Components/Navbar/Navbar";
import "./assets/css/style.css";
import Intro from "./Components/Intro/Intro";

function App() {
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
    </div>
  );
}

export default App;
