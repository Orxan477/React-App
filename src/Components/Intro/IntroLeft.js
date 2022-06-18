import React, { Component } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faCirclePlay } from "@fortawesome/free-solid-svg-icons";

export default class IntroLeft extends Component {
  render() {
    return (
      <div>
        <h1>Better Solutions For Your Business</h1>
        <h2>
          We are team of talented designers making websites with Bootstrap
        </h2>
        <div className="d-flex justify-content-center justify-content-lg-start">
          <a className="btn btn-primary myButton">Get Started</a>
          <a className="video-my">
            <FontAwesomeIcon
              icon={faCirclePlay}
              className="logo"
            ></FontAwesomeIcon>
            <span>Watch Video</span>
          </a>
        </div>
      </div>
    );
  }
}
