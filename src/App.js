import { Container, Row, Col } from "reactstrap";
import Navbar from "./Components/Navbar/Navbar";
import "./assets/css/style.css";
import IntroLeft from "./Components/Intro/IntroLeft";
import IntroRight from "./Components/Intro/IntroRight";

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
            height: "90vh",
          }}
        >
          <Container>
            <Row>
              <Col lg="12" className="Items-intro">
                <Row>
                  <Col lg="6 border" className="left-col">
                    <IntroLeft/>
                  </Col>
                  <Col lg="6 border">
                  <IntroRight/>
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
