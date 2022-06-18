import { Container, Row, Col } from "reactstrap";
import Navbar from "./Components/Navbar/Navbar";

function App() {
  return (
    <div>
      <Container>
        <Row>
          <Navbar />
        </Row>
      </Container>
      <Container fluid className="mt-5">
        <Row>
          <Col lg="12">
            
          </Col>
        </Row>
      </Container>
    </div>
  );
}

export default App;
