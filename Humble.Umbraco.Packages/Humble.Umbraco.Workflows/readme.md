# Umbraco Autopilot

Umbraco Autopilot serves as an extension for the Umbraco Content Management System ("CMS").

Our primary objective with this project is to introduce a user-friendly, low-code solution tailored for content editors within the Umbraco Backoffice. By providing a simple-to-use visual interface, Umbraco Autopilot empowers editors to experiment, prototype, and design seamlessly. This extension allows you to construct intricate workflows and automate processes through visual logic design, all without necessitating extensive coding expertise.

Key attributes of Umbraco Autopilot include:

- **Low-Code Approach:** Embracing a simplified, visual interface, this solution minimizes the reliance on traditional coding. Editors can effortlessly drag and drop components, configure settings, and establish connections between different systems.

- **Seamless Integration:** The extension seamlessly connects distinct applications and services, enabling the smooth exchange of data and triggering specific actions in response to predefined events.

- **Efficient Automation:** Users have the capability to craft workflows that automate repetitive tasks, actions, and procedures across multiple systems. This encompasses functions like data synchronization, notifications, and data transformation.

- **Comprehensive Workflow Orchestration:** Through intuitive visual tools, users can adeptly create intricate logic sequences encompassing actions, decisions, and conditions. This empowers the automation of multifaceted processes in a streamlined manner.

<br><br>

# Get Started Now

1. Add the `Humble.Umbraco.Autopilot` nuget package to your Umbraco project. You may use the Nuget Package Manager, or any console or command line:

```
dotnet add package Humble.Umbraco.Autopilot
```

2. A new section, `Humble`, should appear in the Umbraco Backoffice. Click it.

3. Find `Autopilot` in the section tree. Click it.

4. Build your first workflow!

<br><br>

## Integrations

### Application Lifecycle

Integration|Details
---|---
Recurring Jobs | Schedule recurring jobs using Cron expressions, similar to cron jobs on Unix-based systems. This is particularly useful for tasks that need to run at specific intervals.
Delayed Jobs | You can enqueue jobs to run after a specified delay. This is useful for tasks that should be executed after a certain time has passed.
Fire-and-Forget Jobs | Enqueue a job and let Hangfire handle its execution without waiting for the result.

### Umbraco

Integration|Details|Triggers|Actions
---|---|---|---
Content | | Save, Publish, Unpublish, Delete | Update
Media | | Save, Delete | Update
Members | | Create, Delete | Update
Users | | Create, Delete | Update
Forms | Requires `Umbraco.Forms`, a separate package. | Submission | Update

### Other Systems

System|Details
---|---
Webhooks | 
OpenAI | Whisper, ChatGPT
Email |
SMS | 

<br><br>

## Nodes

### Trigger nodes

Trigger nodes start a workflow and supply the initial data. A workflow can contain multiple trigger nodes but with each execution, only one of them will execute, depending on the triggering event.

System | Detail
---|---
Umbraco Autopilot |
Zapier |
n8n |

### Action nodes

Action nodes perform operations as part of your workflow. These can include manipulating data, and triggering events in other systems.

System | Detail
---|---
Umbraco Autopilot |
Zapier |
n8n |

<br><br>

## Thoughts Regarding Compatibility

The Umbraco Autopilot goals closely align with those of other providers, such as Zapier and n8n. It would be ideal to design and build our system with these providers in mind and develop the necessary code in the process to integrate directly with these providers too.

From ChatGPT:

> Zapier Custom Integrations: Yes, Zapier allows developers to create custom integrations using their Zapier Platform. Developers can build their own apps (called "Zaps") using the Zapier API, which allows you to integrate your software with the Zapier ecosystem. The Zapier API uses REST webhooks and OAuth for authentication. You would typically use programming languages like JavaScript, Python, or any language capable of making HTTP requests to interact with the API.
> 
> n8n Custom Integrations: Similarly, n8n also allows developers to create custom integrations. n8n is open-source and provides a wide range of nodes (integrations) out of the box, but you can extend it by creating custom nodes using JavaScript or TypeScript.
> 
> Designing Umbraco Autopilot for Standalone and Compatibility:
> 
> API-First Approach: To ensure compatibility with both Zapier and n8n, it's a good idea to design your Umbraco Autopilot with an API-first approach. Design your system's core functionality as a set of well-documented APIs that can be used to trigger actions and manage integrations.
> 
> Standardized Formats: Use standardized data formats like JSON or XML for data exchange. Both Zapier and n8n support these formats, making it easier for your system to communicate with them.
> 
> Webhooks: Implement webhook support, as both Zapier and n8n rely heavily on webhooks to trigger actions. Make it easy for external systems to send data to your system via webhooks.
> 
> Authentication and Authorization: Implement secure authentication and authorization mechanisms. OAuth is commonly used for secure authentication in integration platforms like Zapier.
> 
> Documentation: Provide comprehensive documentation for developers who want to integrate with your system. This documentation should cover the API endpoints, authentication methods, data formats, and examples of how to use your system's triggers and actions.
> 
> Modular Architecture: Design your system in a modular way, where triggers and actions can be easily added or extended. This will make it simpler for both your own development team and potential third-party developers to add new features and integrations.
> 
> Testing and Validation: Test your system thoroughly and validate its compatibility with both Zapier and n8n. Use their respective testing and debugging tools to ensure seamless integration.
> 
> By following these guidelines and thinking in terms of creating a flexible, API-centric, and standardized system, you'll increase the chances of both standalone success and compatibility with existing integration platforms like Zapier and n8n.
>
> _- End of the prompt._

<br><br>

> You've reached the end of the document.