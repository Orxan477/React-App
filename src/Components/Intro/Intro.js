import React, { Component } from 'react'
import { Col, Container, Row } from 'reactstrap'
import IntroLeft from './IntroLeft'
import IntroRight from './IntroRight'

export default class Intro extends Component {
  render() {
    return (
        <div className="section-back"
        style={{
          backgroundColor: "#37517e",
          width: "100%",
          height: "90vh",
        }}
      >
        <Container className="relative-section">
          <Row>
            <Col lg="12" className="Items-intro">
              <Row>
                <Col lg="6" className="left-col">
                  <IntroLeft/>
                </Col>
                <Col lg="6">
                <IntroRight/>
                </Col>
              </Row>
            </Col>
          </Row>
        </Container>
      </div>
    )
  }
}
