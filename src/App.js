import { Container, Row, Col } from "reactstrap";
import Navbar from "./Components/Navbar/Navbar";
import "./assets/css/style.css";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faCirclePlay } from "@fortawesome/free-solid-svg-icons";

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
                  <Col lg="6 border" className="left-col">
                    <h1>Better Solutions For Your Business</h1>
                    <h2>
                      We are team of talented designers making websites with
                      Bootstrap
                    </h2>
                    <div className="d-flex justify-content-center justify-content-lg-start">
                      <a className="btn btn-primary myButton">Get Started</a>
                      <a className="video-my">
                        <FontAwesomeIcon icon={faCirclePlay} className="logo"></FontAwesomeIcon>
                        <span>Watch Video</span>
                      </a>
                    </div>
                  </Col>
                  <Col lg="6 border">
                    <div className="d-flex">
                      <img
                        className="img-fluid right-col"
                        src="img/hero-img.png"
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
