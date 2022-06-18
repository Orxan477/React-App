import { Container, Row, Col } from "reactstrap";
import Navbar from "./Components/Navbar/Navbar";
import "../public/assets/css/style.css";

function App() {
  return (
    <div>
      <Container>
        <Row>
          <Navbar />
        </Row>
      </Container>
      <section className="p-0 d-flex relative-section">
        <div
          style={{
            backgroundColor: "#37517e",
            width: "100%",
            height: "85vh",
          }}
        >
          <Container>
            <Row>
              <Col lg="12" className="Items-intro">
                <Row>
                  <Col lg="6 border"></Col>
                  <Col lg="6 border">
                    <div>
                      <img
                        className="img-fluid right-col"
                        src="assets/img/hero-img.png"
                      />
                    </div>
                  </Col>
                </Row>
              </Col>
            </Row>
          </Container>
        </div>
      </section>
    </div>
  );
}

export default App;
