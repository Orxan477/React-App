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
          <section  className="p-0">
            <div
              style={{
                backgroundColor: "#37517e",
                width: "100%",
                height: "85vh",
              }}
            >
              <Container>
              <Row>
                <Col lg="6 border"></Col>
                <Col lg="6 border">
                  <div>
                  <img className="img-fluid"
                    src="assets/img/hero-img.png" />
                  </div>
                </Col>
              </Row>
              </Container>
            </div>
          </section>
        
    </div>
  );
}

export default App;
